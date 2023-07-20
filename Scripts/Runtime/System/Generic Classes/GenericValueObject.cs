using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Dubi.BaseValues
{
    public abstract class GenericValueObject<T> : ScriptableObject, BaseValue
    {
        public T value;
        public bool constantValue;

        [System.NonSerialized] System.Action<T>[] OnValueChangedArray = new System.Action<T>[0];
        [System.NonSerialized] System.Action[] OnValueChangedArrayNoType = new System.Action[0];

        public bool CallbacksRegistered
        {
            get => this.OnValueChangedArray != null && this.OnValueChangedArray.Length > 0;
        }

        public bool CallbacksRegisteredNoType
        {
            get => this.OnValueChangedArrayNoType != null && this.OnValueChangedArrayNoType.Length > 0;
        }

        public void Call()
        {
            foreach (System.Action<T> action in this.OnValueChangedArray)            
                action?.Invoke(this.value);


            foreach (System.Action action in this.OnValueChangedArrayNoType)
                action?.Invoke();
        }

        public void RegisterDelegate(System.Action<T> OnValueChanged)
        {
            List<System.Action<T>> current = this.OnValueChangedArray.ToList();

            if (!current.Contains(OnValueChanged))
            {
                current.Add(OnValueChanged);
            }

            this.OnValueChangedArray = current.ToArray();
        }

        public void DeregisterDelegate(System.Action<T> OnValueChanged)
        {
            List<System.Action<T>> current = this.OnValueChangedArray.ToList();

            if (current.Contains(OnValueChanged))
            {
                current.Remove(OnValueChanged);
            }

            this.OnValueChangedArray = current.ToArray();
        }

        public void RegisterDelegateNoType(System.Action OnValueChanged)
        {
            if (OnValueChanged == null)
                return;

            List<System.Action> current = this.OnValueChangedArrayNoType.ToList();

            if (!current.Contains(OnValueChanged))
            {
                current.Add(OnValueChanged);
            }

            this.OnValueChangedArrayNoType = current.ToArray();
        }

        public void DeregisterDelegateNoType(System.Action OnValueChanged)
        {
            if (OnValueChanged == null)
                return;

            List<System.Action> current = this.OnValueChangedArrayNoType.ToList();

            if (current.Contains(OnValueChanged))
            {
                current.Remove(OnValueChanged);
            }

            this.OnValueChangedArrayNoType = current.ToArray();
        }

        public void CheckValueObjectChange()
        {
            Call();
        }

        public void CheckUseScriptableObject()
        {
            Call();
        }
    }
}