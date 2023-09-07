using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // audio clip
    public class ValueChangedAudioClip : MonoBehaviour
    {
        [SerializeField] AudioClipValue audioClipValue = null;
        [SerializeField] UnityEvent<AudioClip> onValueChanged = null;

        private void OnEnable()
        {
            this.audioClipValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.audioClipValue.DeregisterCallback(SendValue);
        }

        public void SendValue(AudioClip value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}