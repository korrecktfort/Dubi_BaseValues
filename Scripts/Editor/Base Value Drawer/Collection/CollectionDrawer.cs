using Dubi.BaseValues;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Collection<>), true)]
public class CollectionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position.height = EditorGUIUtility.singleLineHeight;
        float width = position.width;


        if(property.objectReferenceValue == null)
        {
            EditorGUI.PropertyField(position, property, new GUIContent(property.displayName), true);
            return;
        }

        SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
        SerializedProperty list = serializedObject.FindProperty("list");

        EditorGUI.BeginChangeCheck();
        property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, GUIContent.none, false);
        if (EditorGUI.EndChangeCheck())
            property.serializedObject.ApplyModifiedProperties();

        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(position, property, new GUIContent(property.displayName), true);
        position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

        if (!property.isExpanded)
            return;

        EditorGUI.indentLevel++;
        float labelWidth = EditorGUIUtility.labelWidth; 
        EditorGUIUtility.labelWidth = 25.0f;
        for (int i = 0; i < list.arraySize; i++)
        {
            EditorGUI.PropertyField(position, list.GetArrayElementAtIndex(i), new GUIContent("-"), true);
            position.y += EditorGUI.GetPropertyHeight(list.GetArrayElementAtIndex(i), true) + EditorGUIUtility.standardVerticalSpacing;
        }
        EditorGUIUtility.labelWidth = labelWidth;
        EditorGUI.indentLevel--;

        if (EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();     
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

        if (!property.isExpanded)
            return height;

        if (property.objectReferenceValue != null)
        {
            SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
            SerializedProperty list = serializedObject.FindProperty("list");
            for (int i = 0; i < list.arraySize; i++)
            {                
                height += EditorGUI.GetPropertyHeight(list.GetArrayElementAtIndex(i), true) + EditorGUIUtility.standardVerticalSpacing;
            }
        }

        return height;        
    }
}