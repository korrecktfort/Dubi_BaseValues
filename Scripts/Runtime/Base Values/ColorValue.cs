using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    [System.Serializable]
    public class ColorValue : GenericBaseValue<Color, ColorValueObject, BaseValueUpdater>
    {
        public ColorValue(Color value) : base(value)
        {
        }
    }
}