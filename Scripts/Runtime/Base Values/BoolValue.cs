using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    [System.Serializable]
    public class BoolValue : GenericBaseValue<bool, BoolValueObject, BaseValueUpdater>
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