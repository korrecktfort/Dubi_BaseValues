using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // rigidbody
    public class ValueChangedRigidbody : MonoBehaviour
    {
        [SerializeField] RigidbodyValue rigidbodyValue = null;
        [SerializeField] UnityEvent<Rigidbody> onValueChanged = null;

        private void OnEnable()
        {
            this.rigidbodyValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.rigidbodyValue.DeregisterCallback(SendValue);
        }

        public void SendValue(Rigidbody value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}