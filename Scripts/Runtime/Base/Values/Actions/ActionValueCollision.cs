using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueCollision : ActionValue<Collision>
    {
        public ActionValueCollision(Action<Collision> value) : base(value)
        {
        }
    }
}
