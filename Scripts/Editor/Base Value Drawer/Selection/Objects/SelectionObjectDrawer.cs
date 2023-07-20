using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Dubi.BaseValues;

[CustomEditor(typeof(SelectionObject<>), true)]
public class SelectionObjectDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        SerializedProperty itemsProp = base.serializedObject.FindProperty("items");
        SerializedProperty valueProp = base.serializedObject.FindProperty("value");               

        int selected = EditorGUILayout.Popup(new GUIContent("Selection"), valueProp.intValue, itemsProp.GetStringList().ToArray());
        
        if (EditorGUI.EndChangeCheck())
        {
            valueProp.intValue = selected;
            base.serializedObject.ApplyModifiedProperties();
        }

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(itemsProp, true);
        if (EditorGUI.EndChangeCheck())
        {
            base.serializedObject.ApplyModifiedProperties();
        }
    }
}