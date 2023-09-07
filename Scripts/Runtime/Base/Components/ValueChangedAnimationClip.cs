using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // animation clip
    public class ValueChangedAnimationClip : MonoBehaviour
    {
        [SerializeField] AnimationClipValue animationClipValue = null;
        [SerializeField] UnityEvent<AnimationClip> onValueChanged = null;

        private void OnEnable()
        {
            this.animationClipValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.animationClipValue.DeregisterCallback(SendValue);
        }

        public void SendValue(AnimationClip value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}