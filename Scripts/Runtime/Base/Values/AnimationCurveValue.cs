using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class AnimationCurveValue : GenericBaseValue<AnimationCurve, AnimationCurveObject, BaseValueUpdater>
    {
        public AnimationCurveValue(AnimationCurve value) : base(value)
        {
        }
    }
}