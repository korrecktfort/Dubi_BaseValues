using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    public class ScriptableObjectValue : GenericBaseValue<ScriptableObject, ScriptableObjectObject, BaseValueUpdater>
    {
        public ScriptableObjectValue(ScriptableObject value) : base(value)
        {
        }
    }

}
