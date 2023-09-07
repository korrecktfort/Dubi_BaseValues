using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // quaternion

    public class ValueChangedQuaternion : MonoBehaviour
    {
        [SerializeField] QuaternionValue quaternionValue = null;
        [SerializeField] UnityEvent<Quaternion> onValueChanged = null;

        private void OnEnable()
        {
            this.quaternionValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.quaternionValue.DeregisterCallback(SendValue);
        }

        public void SendValue(Quaternion value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}