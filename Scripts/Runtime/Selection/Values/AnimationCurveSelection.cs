using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class AnimationCurveSelection : Selection<AnimationCurve, AnimationCurveSelectionObject>
    {
        public AnimationCurveSelection() : base()
        {
        }
    }
}