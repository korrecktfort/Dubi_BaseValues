using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(QuaternionSelection), true)]
public class QuaternionSelectionValueDrawer : SelectionValueDrawer<QuaternionSelectionObject, Quaternion>
{
}
