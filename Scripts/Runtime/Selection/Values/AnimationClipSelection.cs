using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class AnimationClipSelection : Selection<AnimationClip, AnimationClipSelectionObject>
    {
        public AnimationClipSelection() : base()
        {
        }
    }
}