using Dubi.BaseValues;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GenericValueObject<>), true)]
public class BaseValueInspector : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        base.OnInspectorGUI();
        if(EditorGUI.EndChangeCheck() && EditorApplication.isPlaying)
        {
            base.serializedObject.ApplyModifiedProperties();
            if (base.target is BaseValue baseValue)
                baseValue.OnValueChanged();
        }
    }
}
