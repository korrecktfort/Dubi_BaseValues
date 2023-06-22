using System.Collections;
using UnityEngine;
using Rubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(Vector4Value))]
public class Vector4ValueDrawer : BaseValueDrawer<Vector4ValueObject>
{    
    public override float ValueFieldWidth()
    {
        return 200.0f;
    }
}
