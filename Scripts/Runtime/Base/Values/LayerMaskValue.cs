using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class LayerMaskValue : GenericBaseValue<LayerMask, LayerMaskObject, BaseValueUpdater>
    {
        public LayerMaskValue(LayerMask value) : base(value)
        {
        }
    }
}