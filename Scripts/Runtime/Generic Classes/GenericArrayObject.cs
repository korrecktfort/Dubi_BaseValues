using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Rubi.BaseValues
{
    public class GenericArrayObject<T> : ScriptableObject, BaseValue
    {
        public T[] array;
        internal T[] oldArray;
        public bool constantValue;

        [System.NonSerialized] System.Action<T[]>[] OnValueChangedArray = new System.Action<T[]>[0];

        public void CheckForChanges()
        {
            if (!this.array.Equals(this.oldArray))
            {
                CallValueChanges();
                this.oldArray = this.array;
            }
        }

        public void OnStart()
        {
            this.oldArray = this.array;
            CallValueChanges();
        }

        public void ForceCallOnValueChanged()
        {
            CallValueChanges();
            this.oldArray = this.array;
        }

        public void CallValueChanges()
        {
            foreach (System.Action<T[]> action in this.OnValueChangedArray)
            {
                action?.Invoke(this.array);
            }
        }

        public void RegisterDelegate(System.Action<T[]> OnValueChanged)
        {
            List<System.Action<T[]>> current = this.OnValueChangedArray.ToList();

            if (!current.Contains(OnValueChanged))
            {
                current.Add(OnValueChanged);
            }

            this.OnValueChangedArray = current.ToArray();
        }

        public void DeregisterDelegate(System.Action<T[]> OnValueChanged)
        {
            List<System.Action<T[]>> current = this.OnValueChangedArray.ToList();

            if (current.Contains(OnValueChanged))
            {
                current.Remove(OnValueChanged);
            }

            this.OnValueChangedArray = current.ToArray();
        }
        public void CheckForDirectValueChange()
        {
            CheckForChanges();
        }

        public void Call()
        {
            ForceCallOnValueChanged();
        }

        public void CheckValueObjectChange()
        {
        }

        public void CheckUseScriptableObject()
        {
        }

        public void CallOnValueChange()
        {
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!UnityEditor.EditorApplication.isPlaying)
            {
                this.oldArray = this.array;
            }
        }

#endif
    }
}