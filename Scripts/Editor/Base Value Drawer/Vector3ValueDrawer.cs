using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Rubi.BaseValues;

[CustomPropertyDrawer(typeof(Vector3Value))]
public class Vector3ValueDrawer : BaseValueDrawer<Vector3ValueObject>
{
    public override float ValueFieldWidth()
    {
        return 150.0f;
    }
}
