using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class RigidbodyValue : GenericBaseValue<Rigidbody, RigidbodyObject, BaseValueUpdater>
    {
        public RigidbodyValue(Rigidbody value) : base(value)
        {
        }

        public void DeregisterCallback(object onRigidValueChanged)
        {
            throw new NotImplementedException();
        }

        public void RegisterCallback(object onRigidChanged)
        {
            throw new NotImplementedException();
        }
    }
}
