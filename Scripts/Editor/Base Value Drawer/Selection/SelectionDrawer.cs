using Dubi.BaseValues;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Selection<,>), true)]
public class SelectionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        DrawSelection(position, property);
        position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

        if (!property.isExpanded)
            return;

        if (ValidCollection(property))
        {
            DrawSelected(position, property);
            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        }

        DrawCollection(position, property);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = 2.0f * (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing);

        if(!property.isExpanded)
            return height;

        if(ValidSelectedItem(property))
            height += EditorGUI.GetPropertyHeight(SelectedItem(property)) + EditorGUIUtility.standardVerticalSpacing;

        if (ValidCollection(property))
            height += EditorGUI.GetPropertyHeight(CollectionProperty(property)) + EditorGUIUtility.standardVerticalSpacing;

        return height;
    }

    void DrawSelection(Rect position, SerializedProperty property)
    {
        position.height = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(position, property, true);
        if (EditorGUI.EndChangeCheck())
            property.serializedObject.ApplyModifiedProperties();

        if (!ValidSelection(property))
            return;

        position.width = EditorGUIUtility.labelWidth;
        EditorGUI.BeginChangeCheck();
        property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, GUIContent.none, true);
        if (EditorGUI.EndChangeCheck())
            property.serializedObject.ApplyModifiedProperties();
    }

    void DrawCollection(Rect position, SerializedProperty property)
    {
        SerializedProperty collection = CollectionProperty(property);

        if(collection == null)
            return; 

        EditorGUI.indentLevel++;
        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(position, collection, true);
        if (EditorGUI.EndChangeCheck())
            collection.serializedObject.ApplyModifiedProperties();
        EditorGUI.indentLevel--;
    }

    void DrawSelected(Rect position, SerializedProperty property)
    {
        if (!property.isExpanded)
            return;

        EditorGUI.indentLevel++;
        SerializedProperty list = CollectionValue(property);
        
        if (list == null)
            return;        

        float x = position.x;
        float width = position.width;

        float selectionWidth = ValidSelectedItem(property) ? EditorGUIUtility.labelWidth : position.width;

        SerializedProperty selectionIndex = SelectionIndexProperty(property);

        position.height = EditorGUIUtility.singleLineHeight;
        position.width = selectionWidth;

        if(GUI.Button(position, selectionIndex.intValue.ToString()))
        {
            GenericMenu menu = new GenericMenu();

            List<string> stringList = list.GetArrayIndexList();

            for (int i = 0; i < stringList.Count; i++)
            {
                int index = i;

                menu.AddItem(new GUIContent(stringList[i]), selectionIndex.intValue == index, () =>
                {
                    selectionIndex.intValue = index;
                    selectionIndex.serializedObject.ApplyModifiedProperties();

                    BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
                    object sourceObject = CollectionObject(property).targetObject;
                    FieldInfo sourceFieldInfo = sourceObject.GetType().GetField("value", flags);
                    object sourceValue = sourceFieldInfo.GetValue(sourceObject);
                    if(sourceValue is Array array)
                    {
                        object value = array.GetValue(index);
                        SetValueFieldValue(selectionIndex.serializedObject, value);
                    }

                    if (selectionIndex.serializedObject.targetObject is BaseValue baseValue)
                        baseValue.OnValueChanged();
                });
            }

            menu.ShowAsContext();
        }

        SerializedProperty selectionValue = SelectionValue(property);

        position.x = x;
        position.width = width;

        if (selectionValue == null)
            return;

        position.x = x + EditorGUIUtility.labelWidth - 13.0f;
        position.width = width - EditorGUIUtility.labelWidth + 13.0f;
        position.height = EditorGUI.GetPropertyHeight(selectionValue, true);
        EditorGUI.PropertyField(position, selectionValue, GUIContent.none, true);

        position.y += position.height;
        position.x = x;
        position.width = width;
        EditorGUI.indentLevel--;
    }

    bool ValidSelection(SerializedProperty property)
    {
        return property.objectReferenceValue != null;
    }

    bool ValidCollection(SerializedProperty property)
    {
        if (!ValidSelection(property))
            return false;

        SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
        SerializedProperty collection = serializedObject.FindProperty("collection");

        return collection.objectReferenceValue != null;
    }

    bool ValidSelectedItem(SerializedProperty property)
    {
        return SelectedItem(property) != null;
    }

    SerializedProperty SelectedItem(SerializedProperty property)
    {
        if (!ValidCollection(property))
            return null;

        SerializedProperty listValue = CollectionValue(property);
        
        if(listValue == null)
            return null;

        if(!listValue.isArray || listValue.arraySize == 0)
            return null;

        /// Get valid Selection Index
        SerializedProperty selectionIndex = SelectionIndexProperty(property);
        selectionIndex.intValue = Mathf.Clamp(selectionIndex.intValue, 0, listValue.arraySize - 1);
        selectionIndex.serializedObject.ApplyModifiedProperties();

        return listValue.GetArrayElementAtIndex(selectionIndex.intValue);
    }

    SerializedProperty SelectionValue(SerializedProperty property)
    {
        if(!ValidSelection(property))
            return null;

        SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
        
        return serializedObject.FindProperty("value");
    }

    SerializedObject CollectionObject(SerializedProperty property)
    {
        if (!ValidCollection(property))
            return null;

        SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
        SerializedProperty collectionProperty = serializedObject.FindProperty("collection");
        if (collectionProperty.objectReferenceValue == null)
            return null;

        return new SerializedObject(collectionProperty.objectReferenceValue);
    }

    SerializedProperty CollectionValue(SerializedProperty property)
    {
        SerializedObject collectionObject = CollectionObject(property);  

        if(collectionObject == null)
            return null;

        return collectionObject.FindProperty("value");
    }
 
    SerializedProperty SelectionIndexProperty(SerializedProperty property)
    {
        if (!ValidSelection(property))
            return null;

        SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
        return serializedObject.FindProperty("selectionIndex");
    }

    SerializedProperty CollectionProperty(SerializedProperty property)
    {
        if (!ValidSelection(property))
            return null;

        SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
        return serializedObject.FindProperty("collection");
    }

    void SetValueFieldValue(SerializedObject serializedObject, object value)
    {
        BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
        FieldInfo valueField = serializedObject.targetObject.GetType().GetField("value", flags);
        
        if(valueField == null)
            return;

        valueField.SetValue(serializedObject.targetObject, value);
        serializedObject.Update();        
    }
}
