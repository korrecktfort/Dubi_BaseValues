using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // texture
    public class ValueChangedTexture : MonoBehaviour
    {
        [SerializeField] TextureValue textureValue = null;
        [SerializeField] UnityEvent<Texture> onValueChanged = null;

        private void OnEnable()
        {
            this.textureValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.textureValue.DeregisterCallback(SendValue);
        }

        public void SendValue(Texture value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}