using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // vector2
    public class ValueChangedVector2 : MonoBehaviour
    {
        [SerializeField] Vector2Value vector2Value = null;
        [SerializeField] UnityEvent<Vector2> onValueChanged = null;

        private void OnEnable()
        {
            this.vector2Value.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.vector2Value.DeregisterCallback(SendValue);
        }

        public void SendValue(Vector2 value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}