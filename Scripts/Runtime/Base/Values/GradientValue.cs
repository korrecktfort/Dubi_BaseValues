using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class GradientValue : GenericBaseValue<Gradient, GenericValueObject<Gradient>, BaseValueUpdater>
    {
        public GradientValue(Gradient value) : base(value)
        {
        }
    }
}