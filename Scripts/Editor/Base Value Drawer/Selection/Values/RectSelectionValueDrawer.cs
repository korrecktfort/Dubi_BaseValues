using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(RectSelection), true)]
public class RectSelectionValueDrawer : SelectionValueDrawer<RectSelectionObject, Rect>
{
}
