using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class BoolValue : GenericBaseValue<bool, BoolObject, BaseValueUpdater>
    {
        public BoolValue(bool value) : base(value)
        {
        }

        public void ToggleValue()
        {
            base.Value = !base.Value;
        }
    }
}