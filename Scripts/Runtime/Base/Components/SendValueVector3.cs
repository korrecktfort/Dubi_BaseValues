using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    public class SendValueVector3 : MonoBehaviour
    {
        [SerializeField] Vector3Value vector3Value = null;
        [SerializeField] UnityEvent<Vector3> onValueChanged = null;

        private void OnEnable()
        {
            this.vector3Value.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.vector3Value.DeregisterCallback(SendValue);
        }

        public void SendValue(Vector3 value)
        {         
            this.onValueChanged?.Invoke(value);
        }
    }
}