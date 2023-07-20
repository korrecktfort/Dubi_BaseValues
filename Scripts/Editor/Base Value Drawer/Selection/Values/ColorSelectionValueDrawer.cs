using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(ColorSelection), true)]
public class ColorSelectionValueDrawer : SelectionValueDrawer<ColorSelectionObject, Color>
{
}
