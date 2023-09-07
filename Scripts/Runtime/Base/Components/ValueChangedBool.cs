using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // bool
    public class ValueChangedBool : MonoBehaviour
    {
        [SerializeField] BoolValue boolValue = null;
        [SerializeField] UnityEvent<bool> onValueChanged = null;

        private void OnEnable()
        {
            this.boolValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.boolValue.DeregisterCallback(SendValue);
        }

        public void SendValue(bool value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}