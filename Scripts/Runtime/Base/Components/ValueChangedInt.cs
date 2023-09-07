using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // int
    public class ValueChangedInt : MonoBehaviour
    {
        [SerializeField] IntValue intValue = null;
        [SerializeField] UnityEvent<int> onValueChanged = null;

        private void OnEnable()
        {
            this.intValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.intValue.DeregisterCallback(SendValue);
        }

        public void SendValue(int value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}