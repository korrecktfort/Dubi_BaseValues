using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(StringSelection))]
public class StringSelectionValueDrawer : SelectionValueDrawer<StringSelectionObject, string>
{
}
