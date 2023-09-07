using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // sprite
    public class ValueChangedSprite : MonoBehaviour
    {
        [SerializeField] SpriteValue spriteValue = null;
        [SerializeField] UnityEvent<Sprite> onValueChanged = null;

        private void OnEnable()
        {
            this.spriteValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.spriteValue.DeregisterCallback(SendValue);
        }

        public void SendValue(Sprite value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}