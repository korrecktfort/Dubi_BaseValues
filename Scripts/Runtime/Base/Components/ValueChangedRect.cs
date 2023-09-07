using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // rect
    public class ValueChangedRect : MonoBehaviour
    {
        [SerializeField] RectValue rectValue = null;
        [SerializeField] UnityEvent<Rect> onValueChanged = null;

        private void OnEnable()
        {
            this.rectValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.rectValue.DeregisterCallback(SendValue);
        }

        public void SendValue(Rect value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}