using DG.DemiEditor;
using Dubi.BaseValues;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Selection<,>), true)]
public class SelectionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(position, property, label, true);
        if(EditorGUI.EndChangeCheck())
            property.serializedObject.ApplyModifiedProperties();

        if(property.objectReferenceValue != null)
        {
            position.height = EditorGUIUtility.singleLineHeight;
            float width = position.width;

            position.width = EditorGUIUtility.labelWidth;
            EditorGUI.BeginChangeCheck();
            property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, GUIContent.none, true);
            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();
            position.width = width;

            if (!property.isExpanded)
                return;

            EditorGUI.indentLevel++;

            SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
            SerializedProperty selectedIndex = serializedObject.FindProperty("selectionIndex");
            SerializedProperty collection = serializedObject.FindProperty("collection");

            if(collection.objectReferenceValue != null)
            {
                SerializedObject serializedCollection = new SerializedObject(collection.objectReferenceValue);
                SerializedProperty list = serializedCollection.FindProperty("list");
                List<string> arrayIndexes = list.GetArrayIndexList();

                EditorGUI.BeginChangeCheck();
                position.y += position.height;
                selectedIndex.intValue = EditorGUI.Popup(position, selectedIndex.intValue, arrayIndexes.ToArray());

                position.y += position.height;
                EditorGUI.PropertyField(position, list.GetArrayElementAtIndex(selectedIndex.intValue), true);

                if (EditorGUI.EndChangeCheck())
                {
                    selectedIndex.serializedObject.ApplyModifiedProperties();
                    if (serializedObject.targetObject is BaseValue baseValue)
                        baseValue.OnValueChanged();
                }
            }

            EditorGUI.BeginChangeCheck();
            position.y += position.height;
            EditorGUI.PropertyField(position, collection, true);     
            if (EditorGUI.EndChangeCheck())            
                serializedObject.ApplyModifiedProperties();
            
            EditorGUI.indentLevel--;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

        if (!property.isExpanded)
            return height;

        SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
        SerializedProperty selectedIndex = serializedObject.FindProperty("selectionIndex");
        SerializedProperty collection = serializedObject.FindProperty("collection");
        SerializedObject serializedCollection = new SerializedObject(collection.objectReferenceValue);
        SerializedProperty list = serializedCollection.FindProperty("list");

        return height;
    }
}
