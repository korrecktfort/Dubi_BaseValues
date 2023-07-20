using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(BoundsSelection), true)]
public class BoundsSelectionValueDrawer : SelectionValueDrawer<BoundsSelectionObject, Bounds>
{
}
