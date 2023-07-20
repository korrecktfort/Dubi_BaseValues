using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(BoolSelection), true)]
public class BoolSelectionValueDrawer : SelectionValueDrawer<BoolSelectionObject, bool>
{
}
