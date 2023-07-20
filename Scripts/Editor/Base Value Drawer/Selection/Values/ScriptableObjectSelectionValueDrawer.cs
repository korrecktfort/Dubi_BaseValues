using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(ScriptableObjectSelection), true)]
public class ScriptableObjectSelectionValueDrawer : SelectionValueDrawer<ScriptableObjectSelectionObject, ScriptableObject>
{
}
