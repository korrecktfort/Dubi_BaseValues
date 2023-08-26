using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueQuaternion : ActionValue<Quaternion>
    {
        public ActionValueQuaternion() : base(null, true)
        {
        }

        public ActionValueQuaternion(Action<Quaternion> value) : base(value)
        {
        }
    }
}
