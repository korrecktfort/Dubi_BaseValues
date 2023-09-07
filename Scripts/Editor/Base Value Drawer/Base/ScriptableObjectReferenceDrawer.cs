using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Dubi.BaseValues;

[CustomPropertyDrawer(typeof(ScriptableObjectValue))]
public class ScriptableObjectReferenceDrawer : BaseValueDrawer<ScriptableObjectObject>
{
}
