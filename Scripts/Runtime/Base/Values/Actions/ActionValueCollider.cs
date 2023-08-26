using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueCollider : ActionValue<Collider>
    {
        public ActionValueCollider() : base(null, true)
        {
        }

        public ActionValueCollider(Action<Collider> value) : base(value)
        {
        }
    }
}
