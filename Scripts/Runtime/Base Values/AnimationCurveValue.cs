using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    [System.Serializable]
    public class AnimationCurveValue : GenericBaseValue<AnimationCurve, AnimationCurveObject, BaseValueUpdater>
    {
        public AnimationCurveValue(AnimationCurve value) : base(value)
        {
        }
    }
}