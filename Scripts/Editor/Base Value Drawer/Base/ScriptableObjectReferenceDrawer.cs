using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Dubi.BaseValues;

[CustomPropertyDrawer(typeof(ScriptableObjectReference))]
public class ScriptableObjectReferenceDrawer : BaseValueDrawer<ScriptableObjectObject>
{
}
