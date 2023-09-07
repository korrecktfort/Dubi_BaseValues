using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // vector3
    // vector4
    public class ValueChangedVector4 : MonoBehaviour
    {
        [SerializeField] Vector4Value vector4Value = null;
        [SerializeField] UnityEvent<Vector4> onValueChanged = null;

        private void OnEnable()
        {
            this.vector4Value.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.vector4Value.DeregisterCallback(SendValue);
        }

        public void SendValue(Vector4 value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}