using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueGameObject : ActionValue<GameObject>
    {
        public ActionValueGameObject() : base(null, true)
        {
        }

        public ActionValueGameObject(Action<GameObject> value) : base(value)
        {
        }
    }
}
