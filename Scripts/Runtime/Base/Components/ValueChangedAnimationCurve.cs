using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // animation curve
    public class ValueChangedAnimationCurve : MonoBehaviour
    {
        [SerializeField] AnimationCurveValue animationCurveValue = null;
        [SerializeField] UnityEvent<AnimationCurve> onValueChanged = null;

        private void OnEnable()
        {
            this.animationCurveValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.animationCurveValue.DeregisterCallback(SendValue);
        }

        public void SendValue(AnimationCurve value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}