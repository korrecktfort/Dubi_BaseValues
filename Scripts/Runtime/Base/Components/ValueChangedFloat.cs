using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // float
    public class ValueChangedFloat : MonoBehaviour
    {
        [SerializeField] FloatValue floatValue = null;
        [SerializeField] UnityEvent<float> onValueChanged = null;

        private void OnEnable()
        {
            this.floatValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.floatValue.DeregisterCallback(SendValue);
        }

        public void SendValue(float value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}