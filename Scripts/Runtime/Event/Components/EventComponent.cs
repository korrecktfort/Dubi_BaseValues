using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    public class EventComponent : MonoBehaviour
    {
        [SerializeField] CallEventObject callEventObject = null;
        [SerializeField] UnityEvent onActionCalled = null;

        private void OnEnable()
        {
            this.callEventObject.RegisterCallback(CallAction);
        }

        private void OnDisable()
        {
            this.callEventObject.DeregisterCallback(CallAction);
        }

        public void CallAction()
        {
            this.onActionCalled?.Invoke();
        }
    }

}