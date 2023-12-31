﻿using System.Collections;
using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(Vector4Value))]
public class Vector4ValueDrawer : BaseValueDrawer<Vector4Object>
{    
    public override float ValueFieldWidth()
    {
        return 200.0f;
    }
}
