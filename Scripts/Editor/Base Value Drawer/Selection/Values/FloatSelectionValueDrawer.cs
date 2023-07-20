using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(FloatSelection), true)]
public class FloatSelectionValueDrawer : SelectionValueDrawer<FloatSelectionObject, float>
{
}
