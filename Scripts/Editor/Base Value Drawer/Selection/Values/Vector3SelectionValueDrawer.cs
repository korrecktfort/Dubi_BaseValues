using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(Vector3Selection), true)]
public class Vector3SelectionValueDrawer : SelectionValueDrawer<Vector3SelectionObject, Vector3>
{
}
