﻿using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class LayerMaskValue : GenericBaseValue<LayerMask, LayerMaskObject, BaseValueUpdater>
    {
        public LayerMaskValue() : base(default)
        {
        }

        public LayerMaskValue(LayerMask value) : base(value)
        {
        }

        public LayerMask Inverted()
        {
            return ~this.Value;
        }

        public bool Contains(LayerMask layer)
        {
            return (this.Value.value & 1 << layer) > 0;
        }

        public bool Contains(Collision collision)
        {
            if (collision == null)
                return false;

            return this.Contains(collision.gameObject.layer);
        }
    }
}