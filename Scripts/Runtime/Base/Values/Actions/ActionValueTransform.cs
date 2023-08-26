using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueTransform : ActionValue<Transform>
    {
        public ActionValueTransform() : base(null, true)
        {
        }

        public ActionValueTransform(Action<Transform> value) : base(value)
        {
        }
    }
}
