using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // material    
    public class ValueChangedMaterial : MonoBehaviour
    {
        [SerializeField] MaterialValue materialValue = null;
        [SerializeField] UnityEvent<Material> onValueChanged = null;

        private void OnEnable()
        {
            this.materialValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.materialValue.DeregisterCallback(SendValue);
        }

        public void SendValue(Material value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}