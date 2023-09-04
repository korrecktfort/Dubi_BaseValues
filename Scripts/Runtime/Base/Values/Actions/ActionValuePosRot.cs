using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValuePosRot : ActionValue<(Vector3, Quaternion)>
    {
        public ActionValuePosRot() : base(null, true)
        {
        }

        public ActionValuePosRot(Action<(Vector3, Quaternion)> value) : base(value)
        {
        }
    }
}
