using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class CapsuleColliderValue : GenericBaseValue<CapsuleCollider, CapsuleColliderObject, BaseValueUpdater>
    {
        public CapsuleColliderValue(CapsuleCollider value) : base(value)
        {
        }
    }
}
