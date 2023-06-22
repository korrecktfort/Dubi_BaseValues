using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    public class ScriptableObjectReference : GenericBaseValue<ScriptableObject, ScriptableObjectReferenceObject, BaseValueUpdater>
    {
        public ScriptableObjectReference(ScriptableObject value) : base(value)
        {
        }
    }

}
