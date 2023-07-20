using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(IntSelection), true)]
public class IntSelectionValueDrawer : SelectionValueDrawer<IntSelectionObject, int>
{
}
