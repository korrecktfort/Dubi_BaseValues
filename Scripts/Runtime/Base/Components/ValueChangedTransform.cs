using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // transform
    public class ValueChangedTransform : MonoBehaviour
    {
        [SerializeField] TransformValue transformValue = null;
        [SerializeField] UnityEvent<Transform> onValueChanged = null;

        private void OnEnable()
        {
            this.transformValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.transformValue.DeregisterCallback(SendValue);
        }

        public void SendValue(Transform value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}