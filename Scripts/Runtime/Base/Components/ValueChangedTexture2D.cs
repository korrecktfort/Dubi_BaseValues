using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // texture 2D
    public class ValueChangedTexture2D : MonoBehaviour
    {
        [SerializeField] Texture2DValue texture2DValue = null;
        [SerializeField] UnityEvent<Texture2D> onValueChanged = null;

        private void OnEnable()
        {
            this.texture2DValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.texture2DValue.DeregisterCallback(SendValue);
        }

        public void SendValue(Texture2D value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}