using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // sphere collider
    public class ValueChangedSphereCollider : MonoBehaviour
    {
        [SerializeField] SphereColliderValue sphereColliderValue = null;
        [SerializeField] UnityEvent<SphereCollider> onValueChanged = null;

        private void OnEnable()
        {
            this.sphereColliderValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.sphereColliderValue.DeregisterCallback(SendValue);
        }

        public void SendValue(SphereCollider value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}