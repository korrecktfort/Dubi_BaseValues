using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // string value
    public class ValueChangedString : MonoBehaviour
    {
        [SerializeField] StringValue stringValue = null;
        [SerializeField] UnityEvent<string> onValueChanged = null;

        private void OnEnable()
        {
            this.stringValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.stringValue.DeregisterCallback(SendValue);
        }

        public void SendValue(string value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}