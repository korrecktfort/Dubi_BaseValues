using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(AnimationCurveSelection), true)]

public class AnimationCurveSelectionValueDrawer : SelectionValueDrawer<AnimationCurveSelectionObject, AnimationCurve>
{
}
