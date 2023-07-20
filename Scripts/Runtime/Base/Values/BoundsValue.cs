using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class BoundsValue : GenericBaseValue<Bounds, BoundsObject, BaseValueUpdater>
    {
        public BoundsValue(Bounds value) : base(value)
        {
        }
    }
}