using UnityEngine;

namespace Rubi.BaseValues
{
    [System.Serializable]
    public class RectValue : GenericBaseValue<Rect, RectValueObject, BaseValueUpdater>
    {
        public RectValue(Rect value) : base(value)
        {
        }
    }
}