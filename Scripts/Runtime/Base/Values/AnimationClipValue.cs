using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class AnimationClipValue : GenericBaseValue<AnimationClip, AnimationClipObject, BaseValueUpdater>
    {
        public AnimationClipValue(AnimationClip value) : base(value)
        {
        }
    }
}