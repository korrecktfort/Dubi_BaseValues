using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class SphereColliderValue : GenericBaseValue<SphereCollider, SphereColliderObject, BaseValueUpdater>
    {
        public SphereColliderValue(SphereCollider value) : base(value)
        {
        }
    }
}
