using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // box collider
    public class ValueChangedBoxCollider : MonoBehaviour
    {
        [SerializeField] BoxColliderValue boxColliderValue = null;
        [SerializeField] UnityEvent<BoxCollider> onValueChanged = null;

        private void OnEnable()
        {
            this.boxColliderValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.boxColliderValue.DeregisterCallback(SendValue);
        }

        public void SendValue(BoxCollider value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}