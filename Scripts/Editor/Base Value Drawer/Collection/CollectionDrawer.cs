using Dubi.BaseValues;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Collection<>), true)]
public class CollectionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(position, property, label, true);
        if (EditorGUI.EndChangeCheck())        
            property.serializedObject.ApplyModifiedProperties();        

        position.height = EditorGUIUtility.singleLineHeight;
        float width = position.width;

        if(property.objectReferenceValue != null)
        {
            position.width = EditorGUIUtility.labelWidth;
            EditorGUI.BeginChangeCheck();
            property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, GUIContent.none, true);
            if(EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();
            position.width = width;

            if (!property.isExpanded)
                return;

            EditorGUI.indentLevel++;
            EditorGUI.BeginChangeCheck();
            position.y += position.height;
            SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
            EditorGUI.PropertyField(position, serializedObject.FindProperty("list"), true);
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();

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
            height += EditorGUI.GetPropertyHeight(serializedObject.FindProperty("list"));            
        }

        return height;        
    }
}