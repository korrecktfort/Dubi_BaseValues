using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueColor : ActionValue<Color>
    {
        public ActionValueColor() : base(null, true)
        {
        }

        public ActionValueColor(Action<Color> value) : base(value)
        {
        }
    }
}
