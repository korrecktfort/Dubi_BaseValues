using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class RectValue : GenericBaseValue<Rect, RectObject, BaseValueUpdater>
    {
        public RectValue(Rect value) : base(value)
        {
        }
    }
}