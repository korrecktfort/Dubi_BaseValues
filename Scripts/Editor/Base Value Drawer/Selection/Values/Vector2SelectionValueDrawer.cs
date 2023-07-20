using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(Vector2Selection), true)]
public class Vector2SelectionValueDrawer : SelectionValueDrawer<Vector2SelectionObject, Vector2>
{
}
