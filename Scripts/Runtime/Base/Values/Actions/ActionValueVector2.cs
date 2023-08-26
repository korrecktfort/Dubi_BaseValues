using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueVector2 : ActionValue<Vector2>
    {
        public ActionValueVector2() : base(null, true)
        {
        }

        public ActionValueVector2(Action<Vector2> value) : base(value)
        {
        }
    }
}
