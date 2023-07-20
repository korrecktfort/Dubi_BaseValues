using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(AnimationClipSelection), true)]
public class AnimationClipSelectionValueDrawer : SelectionValueDrawer<AnimationClipSelectionObject, AnimationClip>
{
}
