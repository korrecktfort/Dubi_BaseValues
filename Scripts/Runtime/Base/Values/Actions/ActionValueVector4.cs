using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueVector4 : ActionValue<Vector4>
    {
        public ActionValueVector4() : base(null, true)
        {
        }

        public ActionValueVector4(Action<Vector4> value) : base(value)
        {
        }
    }
}
