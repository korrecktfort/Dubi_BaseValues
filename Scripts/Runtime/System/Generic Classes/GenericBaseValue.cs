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
        
        System.Action<T> OnValueChanged = null;
        System.Action OnValueChangedNoType = null;

        [SerializeField] U valueObject = null;
        U oldValueObject = null;

        UpdateType localUpdateType;
        UpdateType localUpdateTypeNoType;

        bool UseRawValue => !this.useScriptableObject || (this.useScriptableObject && this.valueObject == null);

        public bool IsConstant => this.useScriptableObject && this.valueObject != null && this.valueObject.constantValue;

        bool Quitting => this.updater != null && this.updater.LocalQuitting;

        public T Value
        {
            get
            {
                return (this.UseRawValue ? this.value : this.valueObject.value);
            }

            set
            {
                if (this.UseRawValue)
                {
                    this.value = value;
                }
                else
                {
                    this.valueObject.value = value;
                }

                CallOnValueChange();
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

        #region Register To Update Loop

        void RegisterToUpdateLoop(UpdateType updateType)
        {
            /// Check if denied, then if i or my value object has callbacks registered
            this.updater?.Register(updateType, this as BaseValue);            
        }

        void DeregisterFromUpdateLoop(UpdateType updateType)
        {
            /// Check if denied, then if i or my value object has callbacks registered
            this.updater?.Deregister(updateType, this as BaseValue);
        }

        void RegisterToUpdateLoopNoType(UpdateType updateType)
        {
            /// Check if denied, then if i or my value object has callbacks registered
            this.updater?.Register(updateType, this as BaseValue);
        }

        void DeregisterFromUpdateLoopNoType(UpdateType updateType)
        {
            /// Check if denied, then if i or my value object has callbacks registered
            this.updater?.Deregister(updateType, this as BaseValue);
        }

        #endregion

        #region Callbacks
        

        public void RegisterCallback(params Action[] actions)
        {
            if(RegisterActions(true, actions))
            {
                this.localUpdateTypeNoType = UpdateType.Immediate;
            }
        }

        public void RegisterCallback(params Action<T>[] actions)
        {
            if (RegisterActions(true, actions))
            {
                this.localUpdateType = UpdateType.Immediate;
            }
        }

        public void RegisterCallbackSilent(params Action[] actions)
        {
            if(RegisterActions(false, actions))
            {
                this.localUpdateTypeNoType = UpdateType.Immediate;
            }
        }

        public void RegisterCallbackSilent(params Action<T>[] actions)
        {
            if (RegisterActions(false, actions))
            {
                this.localUpdateType = UpdateType.Immediate;
            }
        }

        public void RegisterCallbackLate(params Action[] actions)
        {
            if(RegisterActions(false, actions))
            {
                this.localUpdateTypeNoType = UpdateType.LateUpdate;
                RegisterToUpdateLoopNoType(UpdateType.LateUpdate);
            }                
        }

        public void RegisterCallbackLate(params Action<T>[] actions)
        {
            if (RegisterActions(false, actions))
            {
                this.localUpdateType = UpdateType.LateUpdate;
                RegisterToUpdateLoop(UpdateType.LateUpdate);
            }
        }

        public void RegisterCallbackLateSilent(params Action[] actions)
        {
            if (RegisterActions(false, actions))
            {
                this.localUpdateTypeNoType = UpdateType.LateUpdate;
            }
        }

        public void RegisterCallbackLateSilent(params Action<T>[] actions)
        {
            if (RegisterActions(false, actions))
            {
                this.localUpdateType = UpdateType.LateUpdate;
            }
        }

        public void DeregisterCallback(params Action[] actions)
        {
            DeregisterActions(actions);           
        }

        public void DeregisterCallback(params Action<T>[] actions)
        {
            DeregisterActions(actions);
        }       

        bool RegisterActions<A>(bool callActions, params A[] actions)
        {
            if (this.updater == null)
                this.updater = ValueUpdater<V>.Instance;

            if (Quitting)
                return false;

            if (actions == null || actions.Length == 0)
                return false;
                        
            bool useRawValue = UseRawValue;
            if(!useRawValue && this.valueObject == null)
            {
#if UNITY_EDITOR
                Debug.LogWarning("No Scriptable Object Found, using Raw Value");
#endif
            }

            foreach(A action in actions)
            {
                switch(action)
                {
                    case Action:
                        Action a0 = action as Action;
                        this.OnValueChangedNoType -= a0;
                        this.OnValueChangedNoType += a0;
                        break;

                    case Action<T>:
                        Action<T> a1 = action as Action<T>;
                        this.OnValueChanged -= a1;
                        this.OnValueChanged += a1;
                        break;
                }
            }

            if (!useRawValue)
            {
                if(this.OnValueChanged != null)
                    this.valueObject?.RegisterDelegate(this.OnValueChanged);
                
                if (this.OnValueChangedNoType != null)
                    this.valueObject?.RegisterDelegateNoType(this.OnValueChangedNoType);
            }

            if (callActions)
            {
                Call();
            }

            return true;
        }

        void DeregisterActions<A>(A[] actions)
        {
            if(Quitting)
                return;

            DeregisterFromUpdateLoop(UpdateType.LateUpdate);
            DeregisterFromUpdateLoopNoType(UpdateType.LateUpdate);

            this.valueObject?.DeregisterDelegate(this.OnValueChanged);
            this.valueObject?.DeregisterDelegateNoType(this.OnValueChangedNoType);
            
            if(actions != null && actions.Length > 0)
            {
                foreach(A action in actions)
                {
                    switch (action)
                    {
                        case Action:
                            this.OnValueChangedNoType -= action as Action;
                            break;

                        case Action<T>:
                            this.OnValueChanged -= action as Action<T>;
                            break;
                    }
                }
            }
        }
        #endregion

        public void CallOnValueChange()
        {
            if (this.localUpdateType == UpdateType.LateUpdate)
            {
                RegisterToUpdateLoop(UpdateType.LateUpdate);
                return;
            }

            if (this.localUpdateTypeNoType == UpdateType.LateUpdate)
            {
                RegisterToUpdateLoopNoType(UpdateType.LateUpdate);
                return;
            }

            Call();
        }

        public void Call()
        {
            if (Quitting)
                return;

            if (UseRawValue)
            {
                this.OnValueChanged?.Invoke(this.value);
                this.OnValueChangedNoType?.Invoke();                
            }
            else            
                this.valueObject.Call();
        }

        public void CheckValueObjectChange()
        {
            /// On Scriptable Object Change
            if (this.valueObject != this.oldValueObject)
            {
                /// Take delegates from old and subscribe to new object
                this.oldValueObject?.DeregisterDelegate(this.OnValueChanged);
                this.oldValueObject?.DeregisterDelegateNoType(this.OnValueChangedNoType);

                this.valueObject?.RegisterDelegate(this.OnValueChanged);
                this.valueObject?.RegisterDelegateNoType(this.OnValueChangedNoType);

                /// Force call send new values of new scriptable object
                this.OnValueChanged?.Invoke(this.valueObject.value);
                this.OnValueChangedNoType?.Invoke();

                this.oldValueObject = this.valueObject;
            }
        }

        public void CheckUseScriptableObject()
        {
            /// On Value Source Change            
            if (this.UseRawValue)
            {
                if(this.valueObject != null)
                {
                    this.valueObject.DeregisterDelegate(this.OnValueChanged);
                    this.valueObject.DeregisterDelegateNoType(this.OnValueChangedNoType);
                }
            }
            else
            {
                if (this.OnValueChanged != null)                                    
                    this.valueObject?.RegisterDelegate(this.OnValueChanged);
                

                if (this.OnValueChangedNoType != null)                                    
                    this.valueObject?.RegisterDelegateNoType(this.OnValueChangedNoType);                
            }

            this.oldUseScriptableObject = this.useScriptableObject;

            Call();
        }
    }
}