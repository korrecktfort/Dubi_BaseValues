using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // layer mask
    public class ValueChangedLayerMask : MonoBehaviour
    {
        [SerializeField] LayerMaskValue layerMaskValue = null;
        [SerializeField] UnityEvent<LayerMask> onValueChanged = null;

        private void OnEnable()
        {
            this.layerMaskValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.layerMaskValue.DeregisterCallback(SendValue);
        }

        public void SendValue(LayerMask value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}