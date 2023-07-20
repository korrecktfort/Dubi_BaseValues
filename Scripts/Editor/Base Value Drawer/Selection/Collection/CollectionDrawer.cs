using Dubi.BaseValues;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class CollectionDrawer<T, U> : PropertyDrawer where U : CollectionObject<T>
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty collection = property.FindPropertyRelative("collection");
        if(collection.objectReferenceValue == null)
        {
            EditorGUI.PropertyField(position, collection, label);
            return;
        }

        float width = position.width;        
        float buttonWidth = EditorGUIUtility.singleLineHeight;
        position.height = EditorGUIUtility.singleLineHeight;
        
        float fieldWidth = (width - buttonWidth) * 0.5f;

        SerializedObject serializedObject = new SerializedObject(collection.objectReferenceValue);
        SerializedProperty selection = property.FindPropertyRelative("selection");
        int selectionIndex = selection.intValue;
        SerializedProperty itemsProp = serializedObject.FindProperty("list");
        SerializedProperty prop = itemsProp.GetArrayElementAtIndex(selectionIndex);

        position.width = fieldWidth;

        EditorGUI.BeginChangeCheck();
        
        float labelWidth = EditorGUIUtility.labelWidth;
        EditorGUIUtility.labelWidth = 6.0f;
        EditorGUI.PropertyField(position, prop, new GUIContent("-"));
        EditorGUIUtility.labelWidth = labelWidth;
        if (EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();

        position.x += fieldWidth;

        EditorGUI.BeginChangeCheck();        
        int newSelectedIndex = EditorGUI.Popup(position, selectionIndex, itemsProp.GetStringList().ToArray());        
        if (EditorGUI.EndChangeCheck())
        {
            selection.intValue = newSelectedIndex;
            property.serializedObject.ApplyModifiedProperties();
        }

        position.x += fieldWidth;
        position.width = buttonWidth;

        using (new EditorGUIUtility.IconSizeScope(Vector2.one * EditorGUIUtility.singleLineHeight - Vector2.one * 2.0f))
        {
            if (GUI.Button(position, EditorGUIUtility.IconContent("d_clear")))
            {
                collection.objectReferenceValue = null;
                property.serializedObject.ApplyModifiedProperties();
            }
        }     
    }    
}

[CustomPropertyDrawer(typeof(ColorCollection))]
public class ColorCollectionDrawer : CollectionDrawer<Color, ColorCollectionObject>
{
}
