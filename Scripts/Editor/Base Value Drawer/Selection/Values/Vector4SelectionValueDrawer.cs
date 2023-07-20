using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(Vector4Selection), true)]
public class Vector4SelectionValueDrawer : SelectionValueDrawer<Vector4SelectionObject, Vector4>
{
}
