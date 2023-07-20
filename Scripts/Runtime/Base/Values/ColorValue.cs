using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ColorValue : GenericBaseValue<Color, ColorObject, BaseValueUpdater>
    {
        public ColorValue(Color value) : base(value)
        {
        }
    }
}