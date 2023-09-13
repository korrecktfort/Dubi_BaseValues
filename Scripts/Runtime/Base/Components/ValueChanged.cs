using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    public abstract class ValueChanged<T, U> : MonoBehaviour where T : BaseValue<U>
    {
        [SerializeField] T value = default;
        [SerializeField] UnityEvent<U> onValueChanged = default;        

        [SerializeField, Tooltip("Register without calling the Unity Event")] BoolValue silent;
        [SerializeField, Tooltip("Value changes will apply on Late Update")] BoolValue late;

        private void OnEnable()
        {
            if (this.silent.Value)
            {
                if(this.late.Value)
                {
                    this.value.RegisterCallbackLateSilent(OnValueChanged);
                }
                else
                {
                    this.value.RegisterCallbackSilent(OnValueChanged);
                }
            }
            else
            {
                if(this.late.Value)
                {
                    this.value.RegisterCallbackLate(OnValueChanged);
                }
                else
                {
                    this.value.RegisterCallback(OnValueChanged);
                }
            }
        }

        private void OnDisable()
        {
            this.value.DeregisterCallback(OnValueChanged);            
        }

        void OnValueChanged(U value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }
}