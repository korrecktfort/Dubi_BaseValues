using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Rubi.BaseValues;

[CustomPropertyDrawer(typeof(MonoReference<MonoBehaviour>))]
public class MonoReferenceDrawer : BaseValueDrawer<MonoReferenceObject>
{
    
}
