using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Dubi.BaseValues;

[CustomPropertyDrawer(typeof(Vector2Value))]
public class Vector2ValueDrawer : BaseValueDrawer<Vector2Object>
{
    protected override void DisplayValueField(Rect position, SerializedProperty property)
    {
        if (property == null)
            return;

        EditorGUI.BeginChangeCheck();

        float labelWidth = EditorGUIUtility.labelWidth;
        EditorGUIUtility.labelWidth = gapAfterButton;

        float halfWidth = position.width * 0.5f;

        position.width = halfWidth;
        EditorGUI.PropertyField(position, property.FindPropertyRelative("x"));
        position.x += halfWidth;
        EditorGUI.PropertyField(position, property.FindPropertyRelative("y"));

        // EditorGUI.DrawRect(position, Color.red);
        // EditorGUI.PropertyField(position, property, EditorGUIUtility.IconContent("d_Toolbar Minus@2x"), true);        
        
        EditorGUIUtility.labelWidth = labelWidth;

        if (EditorGUI.EndChangeCheck())
        {
            property.serializedObject.ApplyModifiedProperties();
            Call();
        }
    }

    //public override float ValueFieldWidth()
    //{
    //    return 150.0f;
    //}
}
