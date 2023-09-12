using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class Vector2Value : GenericBaseValue<Vector2, Vector2Object, BaseValueUpdater>
    {
        public Vector2Value(Vector2 value) : base(value)
        {
        }

        public void RegisterCallback(object onScreenResolutionChanged)
        {
            throw new NotImplementedException();
        }
    }
}