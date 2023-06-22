using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    [System.Serializable]
    public class TransformValue : GenericBaseValue<Transform, TransformValueObject, BaseValueUpdater>
    {
        public TransformValue(Transform value) : base(value)
        {
        }
    }
}
