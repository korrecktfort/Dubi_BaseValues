using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Rubi.BaseValues;

[CustomPropertyDrawer(typeof(ScriptableObjectReference))]
public class ScriptableObjectReferenceDrawer : BaseValueDrawer<ScriptableObjectReferenceObject>
{
}
