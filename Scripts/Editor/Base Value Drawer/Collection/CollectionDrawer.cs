using DG.Tweening.Core;
using Dubi.BaseValues;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(Collection<>), true)]
public class CollectionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position.height = EditorGUIUtility.singleLineHeight;

        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(position, property, label, true);
        if (EditorGUI.EndChangeCheck())
            property.serializedObject.ApplyModifiedProperties();

        float width = position.width;

        if (property.objectReferenceValue == null)
            return;

        SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
        SerializedProperty value = serializedObject.FindProperty("value");
        
        if(value.arraySize == 0)
            return;

        position.width = EditorGUIUtility.labelWidth;
        EditorGUI.BeginChangeCheck();
        property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, GUIContent.none, true);
        if (EditorGUI.EndChangeCheck())
            property.serializedObject.ApplyModifiedProperties();
        position.width = width;

        position.y += position.height + EditorGUIUtility.standardVerticalSpacing;

        if (property.isExpanded)
        {

            EditorGUI.indentLevel++;
            EditorGUI.BeginChangeCheck();

            for (int i = 0; i < value.arraySize; i++)
            {
                SerializedProperty item = value.GetArrayElementAtIndex(i);
                EditorGUI.PropertyField(position, item, true);
                position.y += EditorGUI.GetPropertyHeight(item) + EditorGUIUtility.standardVerticalSpacing;
            }

            if (EditorGUI.EndChangeCheck())
            {     
                value.serializedObject.ApplyModifiedProperties();

                if (serializedObject.targetObject is BaseValue baseValue)
                    baseValue.OnValueChanged();
            }
            EditorGUI.indentLevel--;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

        if (property.objectReferenceValue != null)
        {
            if (!property.isExpanded)
                return height;

            SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
            SerializedProperty value = serializedObject.FindProperty("value");

            for (int i = 0; i < value.arraySize; i++)
            {
                SerializedProperty item = value.GetArrayElementAtIndex(i);
                height += EditorGUI.GetPropertyHeight(item) + EditorGUIUtility.standardVerticalSpacing;
            }            
        }

        return height;        
    }
}