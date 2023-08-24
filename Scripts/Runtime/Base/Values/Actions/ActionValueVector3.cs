using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueVector3 : ActionValue<Vector3>
    {
        public ActionValueVector3(Action<Vector3> value) : base(value)
        {
        }
    }
}
