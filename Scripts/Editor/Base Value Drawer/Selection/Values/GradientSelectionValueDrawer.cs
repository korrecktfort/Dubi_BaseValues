using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(GradientSelection), true)]
public class GradientSelectionValueDrawer : SelectionValueDrawer<GradientSelectionObject, Gradient>
{
}
