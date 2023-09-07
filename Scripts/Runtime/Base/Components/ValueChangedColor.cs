using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // color 
    public class ValueChangedColor : MonoBehaviour
    {
        [SerializeField] ColorValue colorValue = null;
        [SerializeField] UnityEvent<Color> onValueChanged = null;

        private void OnEnable()
        {
            this.colorValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.colorValue.DeregisterCallback(SendValue);
        }

        public void SendValue(Color value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}