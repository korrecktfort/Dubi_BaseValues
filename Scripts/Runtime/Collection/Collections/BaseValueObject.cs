using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    public abstract class BaseValueObject<T> : ScriptableObject, BaseValue<T>
    {
        [SerializeField] protected T value = default;

        [NonSerialized] Action onValueChangedNoType = null;
        [NonSerialized] Action<T> onValueChanged = null;

        [NonSerialized] Action onValueChangedNoTypeLate = null;
        [NonSerialized] Action<T> onValueChangedLate = null;

        [NonSerialized] BaseValueUpdater updater = null;

        public void OnValueChanged()
        {
            Call();
            this.updater?.RegisterLate(CallLate);
        }

        void TryRegisterUpdater()
        {
            if (this.updater == null)
                this.updater = BaseValueUpdater.Instance;
        }

        void TryDeregisterUpdater()
        {
            if(this.updater != null && this.onValueChangedLate == null && this.onValueChangedNoTypeLate == null)
                this.updater = null;
        }

        public void RegisterCallback(params Action[] actions)
        {
            RegisterCallbackSilent(actions);

            Call();
        }

        public void RegisterCallback(params Action<T>[] actions)
        {
            RegisterCallbackSilent(actions);

            Call();
        }

        public void RegisterCallbackSilent(params Action[] actions)
        {
            foreach (var action in actions)
            {
                this.onValueChangedNoType -= action;
                this.onValueChangedNoType += action;
            }
        }

        public void RegisterCallbackSilent(params Action<T>[] actions)
        {
            foreach (var action in actions)
            {
                this.onValueChanged -= action;
                this.onValueChanged += action;
            }
        }

        public void RegisterCallbackLate(params Action[] actions)
        {
            RegisterCallbackLateSilent(actions);

            this.updater?.RegisterLate(CallLate);
        }

        public void RegisterCallbackLate(params Action<T>[] actions)
        {
            RegisterCallbackLateSilent(actions);

            this.updater?.RegisterLate(CallLate);
        }

        public void RegisterCallbackLateSilent(params Action[] actions)
        {
            TryRegisterUpdater();

            foreach (var action in actions)
            {
                this.onValueChangedNoTypeLate -= action;
                this.onValueChangedNoTypeLate += action;
            }
        }

        public void RegisterCallbackLateSilent(params Action<T>[] actions)
        {
            TryRegisterUpdater();

            foreach (var action in actions)
            {
                this.onValueChangedLate -= action;
                this.onValueChangedLate += action;
            }
        }

        public void DeregisterCallback(params Action[] actions)
        {
            foreach (var action in actions)
            {
                this.onValueChangedNoType -= action;
                this.onValueChangedNoTypeLate -= action;
            }

            TryDeregisterUpdater();
        }

        public void DeregisterCallback(params Action<T>[] actions)
        {
            foreach (var action in actions)
            {
                this.onValueChanged -= action;
                this.onValueChangedLate -= action;
            }

            TryDeregisterUpdater();
        }

        public void Call()
        {
            this.onValueChanged?.Invoke(this.value);
            this.onValueChangedNoType?.Invoke();
        }

        public void CheckValueObjectChange()
        {
            Call();
        }

        public void CheckUseScriptableObject()
        {
            Call();
        }

        public void CallLate()
        {
            this.onValueChangedLate?.Invoke(this.value);
            this.onValueChangedNoTypeLate?.Invoke();
        }
    }
}