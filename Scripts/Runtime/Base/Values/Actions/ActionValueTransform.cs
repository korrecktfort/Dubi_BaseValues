using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueTransform : ActionValue<Transform>
    {
        public ActionValueTransform(Action<Transform> value) : base(value)
        {
        }
    }
}
