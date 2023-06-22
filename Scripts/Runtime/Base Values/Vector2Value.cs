using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    [System.Serializable]
    public class Vector2Value : GenericBaseValue<Vector2, Vector2ValueObject, BaseValueUpdater>
    {
        public Vector2Value(Vector2 value) : base(value)
        {
        }
    }
}