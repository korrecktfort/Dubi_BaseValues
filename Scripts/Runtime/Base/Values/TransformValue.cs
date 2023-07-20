using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class TransformValue : GenericBaseValue<Transform, TransformObject, BaseValueUpdater>
    {
        public TransformValue(Transform value) : base(value)
        {
        }
    }
}
