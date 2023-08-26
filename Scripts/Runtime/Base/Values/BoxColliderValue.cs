using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class BoxColliderValue : GenericBaseValue<BoxCollider, BoxColliderObject, BaseValueUpdater>
    {
        public BoxColliderValue(BoxCollider value) : base(value)
        {
        }
    }
}
