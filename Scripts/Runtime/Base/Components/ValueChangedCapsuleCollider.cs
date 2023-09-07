using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // capsule collider

    public class ValueChangedCapsuleCollider : MonoBehaviour
    {
        [SerializeField] CapsuleColliderValue capsuleColliderValue = null;
        [SerializeField] UnityEvent<CapsuleCollider> onValueChanged = null;

        private void OnEnable()
        {
            this.capsuleColliderValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.capsuleColliderValue.DeregisterCallback(SendValue);
        }

        public void SendValue(CapsuleCollider value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}