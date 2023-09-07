using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // gradient
    public class ValueChangedGradient : MonoBehaviour
    {
        [SerializeField] GradientValue gradientValue = null;
        [SerializeField] UnityEvent<Gradient> onValueChanged = null;

        private void OnEnable()
        {
            this.gradientValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.gradientValue.DeregisterCallback(SendValue);
        }

        public void SendValue(Gradient value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}