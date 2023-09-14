using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public abstract class GenericBaseValue<T, U, V> : BaseValue<T> where U : GenericValueObject<T> where V : ValueUpdater<V>
    {
        ValueUpdater<V> updater = null;

        [SerializeField] bool forceScriptableObject = false;
        [SerializeField] bool useScriptableObject = false;
        bool oldUseScriptableObject = false;
 
        [SerializeField] T value;
        
        [NonSerialized] Action<T> onValueChanged = null;
        [NonSerialized] Action onValueChangedNoType = null;

        [NonSerialized] Action<T> onValueChangedLate = null;
        [NonSerialized] Action onValueChangedNoTypeLate = null;

        [SerializeField] U valueObject = null;
        U oldValueObject = null;

        bool UseRawValue => !this.useScriptableObject || (this.useScriptableObject && this.valueObject == null);

        public bool IsConstant => this.useScriptableObject && this.valueObject != null && this.valueObject.ConstantValue;

        bool Quitting => this.updater != null && this.updater.LocalQuitting;

        public T Value
        {
            get => this.UseRawValue ? this.value : this.valueObject.Value;
            
            set
            {
                if (this.UseRawValue)                
                    this.value = value;                
                else                
                    this.valueObject.Value = value;

                OnValueChanged();
            }
        }

        protected U ValueObject
        {
            set
            {
                this.useScriptableObject = value != null;
                this.valueObject = value;
                CheckValueObjectChange();
            }
            get => this.valueObject;
        }

        public T RawValue
        {
            set => this.value = value;
            get => this.value;
        }

        public GenericBaseValue(T value)
        {
            this.value = value;
        }

        public GenericBaseValue(T value, bool forceScriptableObject) : this(value)
        {
            if (forceScriptableObject)
            {
                this.forceScriptableObject = forceScriptableObject;
                this.useScriptableObject = true;
            }
        }

        #region Callbacks
        

        public void RegisterCallback(params Action[] actions)
        {
            RegisterCallbackSilent(actions);
                
            OnValueChanged();
        }

        public void RegisterCallback(params Action<T>[] actions)
        {
            RegisterCallbackSilent(actions);

            OnValueChanged();
        }
        public void RegisterCallbackLate(params Action[] actions)
        {
            RegisterCallbackLateSilent(actions);

            OnValueChanged();
        }

        public void RegisterCallbackLate(params Action<T>[] actions)
        {
            RegisterCallbackLateSilent(actions);

            OnValueChanged();
        }

        public void RegisterCallbackSilent(params Action[] actions)
        {
            DeregisterCallBacksFromValueObject();

            foreach(var action in actions)
            {
                this.onValueChangedNoType -= action;
                this.onValueChangedNoType += action;
            }

            RegisterCallbacksToValueObject();
        }

        public void RegisterCallbackSilent(params Action<T>[] actions)
        {
            DeregisterCallBacksFromValueObject();

            foreach(var action in actions)
            {
                this.onValueChanged -= action;
                this.onValueChanged += action;
            }

            RegisterCallbacksToValueObject();
        }


        public void RegisterCallbackLateSilent(params Action[] actions)
        {
            TryRegisterUpdater();

            DeregisterCallBacksFromValueObject();

            foreach(var action in actions)
            {
                this.onValueChangedNoTypeLate -= action;
                this.onValueChangedNoTypeLate += action;
            }

            RegisterCallbacksToValueObject();
        }

        public void RegisterCallbackLateSilent(params Action<T>[] actions)
        {
            TryRegisterUpdater();

            DeregisterCallBacksFromValueObject();

            foreach(var action in actions)
            {
                this.onValueChangedLate -= action;
                this.onValueChangedLate += action;
            }

            RegisterCallbacksToValueObject();
        }

        public void DeregisterCallback(params Action[] actions)
        {
            DeregisterCallBacksFromValueObject();

            foreach(var action in actions)
            {
                this.onValueChangedNoType -= action;
                this.onValueChangedNoTypeLate -= action;
            }

            TryDeregisterUpdater();
        }

        public void DeregisterCallback(params Action<T>[] actions)
        {
            DeregisterCallBacksFromValueObject();

            foreach(var action in actions)
            {
                this.onValueChanged -= action;
                this.onValueChangedLate -= action;
            }

            TryDeregisterUpdater();
        }
        #endregion

        void TryRegisterUpdater()
        {
            if(this.updater == null)
                this.updater = ValueUpdater<V>.Instance;
        }

        void TryDeregisterUpdater()
        {
            if(this.onValueChangedLate == null && this.onValueChangedNoTypeLate == null)
                this.updater = null;
        }

        public void OnValueChanged()
        {
            if (Quitting)
                return;

            Call();
                        
            this.updater?.RegisterLate(CallLate);
        }

        public void Call()
        {           
            if (UseRawValue)
            {
                this.onValueChanged?.Invoke(this.value);
                this.onValueChangedNoType?.Invoke();                
            }
            else            
                this.valueObject.Call();
        }

        public void CallLate()
        {
            if (UseRawValue)
            {
                this.onValueChangedLate?.Invoke(this.value);
                this.onValueChangedNoTypeLate?.Invoke();
            }
            else
                this.valueObject.CallLate();
        }

        public void CheckValueObjectChange()
        {
            /// On Scriptable Object Change
            if (this.valueObject != this.oldValueObject)
            {
                /// Take delegates from old and subscribe to new object
                this.oldValueObject?.DeregisterCallback(this.onValueChanged, this.onValueChangedLate);
                this.oldValueObject?.DeregisterCallback(this.onValueChangedNoType, onValueChangedNoTypeLate);

                RegisterCallbacksToValueObject(true);

                this.oldValueObject = this.valueObject;
            }
        }

        public void CheckUseScriptableObject()
        {
            /// On Value Source Change            
            if (this.UseRawValue)            
                DeregisterCallBacksFromValueObject();                                                
            else            
                RegisterCallbacksToValueObject();            

            this.oldUseScriptableObject = this.useScriptableObject;

            OnValueChanged();
        }

        void RegisterCallbacksToValueObject(bool call = false)
        {
            if (this.UseRawValue)
                return;

            this.valueObject?.RegisterCallbackSilent(this.onValueChanged);
            this.valueObject?.RegisterCallbackLateSilent(this.onValueChangedLate);

            this.valueObject?.RegisterCallbackSilent(this.onValueChangedNoType);
            this.valueObject?.RegisterCallbackLateSilent(this.onValueChangedNoTypeLate);

            if (call)
                this.valueObject?.OnValueChanged();
        }

        void DeregisterCallBacksFromValueObject()
        {
            this.valueObject?.DeregisterCallback(this.onValueChanged, this.onValueChangedLate);
            this.valueObject?.DeregisterCallback(this.onValueChangedNoType, onValueChangedNoTypeLate);
        }        
    }
}