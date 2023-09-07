using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // bounds
    public class ValueChangedBounds : MonoBehaviour
    {
        [SerializeField] BoundsValue boundsValue = null;
        [SerializeField] UnityEvent<Bounds> onValueChanged = null;

        private void OnEnable()
        {
            this.boundsValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.boundsValue.DeregisterCallback(SendValue);
        }

        public void SendValue(Bounds value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}