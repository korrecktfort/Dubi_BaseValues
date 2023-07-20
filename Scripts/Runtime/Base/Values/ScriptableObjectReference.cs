using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    public class ScriptableObjectReference : GenericBaseValue<ScriptableObject, ScriptableObjectObject, BaseValueUpdater>
    {
        public ScriptableObjectReference(ScriptableObject value) : base(value)
        {
        }
    }

}
