using System.Collections.Generic;
using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;
using System.Xml.Schema;

//[CustomPropertyDrawer(typeof(SelectionValue<,>), true)] 
public abstract class SelectionValueDrawer<T, U> : BaseValueDrawer<T> where T : SelectionObject<U>, new()
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty valueObject = property.FindPropertyRelative("valueObject");

        if(valueObject.objectReferenceValue == null)
        {
            EditorGUI.PropertyField(position, valueObject, new GUIContent(property.displayName), true);
            return;
        }        

        SerializedObject serializedValueObject = new SerializedObject(valueObject?.objectReferenceValue);

        if (serializedValueObject == null)
            return;

        SerializedProperty valueProp = BaseValueHelper.GetValueProp(property);
        SerializedProperty itemsProp = serializedValueObject.FindProperty("items");


        EditorGUI.BeginChangeCheck();
        position.height = EditorGUIUtility.singleLineHeight;

        float buttonWidth = EditorGUIUtility.singleLineHeight;
        float x = position.x;
        float width = position.width;
        float selectionWidth = 35.0f;

        position.width = 0.0f;
        EditorGUI.BeginChangeCheck();
        property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, GUIContent.none, true);
        if (EditorGUI.EndChangeCheck())
        {
            property.serializedObject.ApplyModifiedProperties();
        }
        position.width = width;

        if(!property.isExpanded)
        {
            EditorGUI.PropertyField(position, valueObject, new GUIContent(property.displayName), true);
            return;
        }

        if (itemsProp.arraySize == 0)
        {
            EditorGUI.PropertyField(position, valueObject, new GUIContent(property.displayName), true);

            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            EditorGUI.LabelField(position, "No Items");

            return;
        }

        position.width = EditorGUIUtility.labelWidth;
        EditorGUI.LabelField(position, label);
        position.x += position.width;

       
        position.width = selectionWidth;
        int value = EditorGUI.Popup(position, valueProp.intValue, itemsProp.GetArrayIndexList().ToArray());
        position.x += position.width;

        position.width = width - EditorGUIUtility.labelWidth - selectionWidth - buttonWidth * 2.0f;
        EditorGUI.PropertyField(position, itemsProp.GetArrayElementAtIndex(valueProp.intValue), GUIContent.none, true);
        position.x += position.width;

        position.width = buttonWidth;

        using (new EditorGUIUtility.IconSizeScope(Vector2.one * EditorGUIUtility.singleLineHeight - Vector2.one * 9.0f))
        {
            if (GUI.Button(position, EditorGUIUtility.IconContent("d_pick")))
            {
                EditorGUIUtility.PingObject(valueObject.objectReferenceValue);
            }
        }

        position.x += buttonWidth;

        using (new EditorGUIUtility.IconSizeScope(Vector2.one * EditorGUIUtility.singleLineHeight - Vector2.one * 1.6f))
        {
            if (GUI.Button(position, EditorGUIUtility.IconContent("d_clear")))
            {
                valueObject.objectReferenceValue = null;
                property.serializedObject.ApplyModifiedProperties();

                base.CheckValueObjectChange();
            }
        }

        if (EditorGUI.EndChangeCheck())
        {
            valueProp.intValue = value;
            valueProp.serializedObject.ApplyModifiedProperties();
            property.serializedObject.ApplyModifiedProperties();
            itemsProp.serializedObject.ApplyModifiedProperties();

            base.Call();
        }

        if (!property.isExpanded)
            return;

        position.x = x;
        position.width = width;
        position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;      

        EditorGUI.indentLevel++;
        EditorGUI.BeginChangeCheck();

        x = position.x;
        float labelWidth = EditorGUIUtility.labelWidth;
        float fieldWidth = position.width - buttonWidth - EditorGUIUtility.labelWidth;
        buttonWidth = EditorGUIUtility.singleLineHeight;

        for (int i = 0; i < itemsProp.arraySize; i++)
        {
            position.x = x;
            position.width = labelWidth;
            EditorGUI.LabelField(position, new GUIContent(i.ToString()));

            position.x += labelWidth;
            position.width = buttonWidth;
            using (new EditorGUIUtility.IconSizeScope(Vector2.one * EditorGUIUtility.singleLineHeight - Vector2.one * 1.6f))
            {
                if (GUI.Button(position, new GUIContent("s", "Quick Select")))
                {
                    int index = i;
                    valueProp.intValue = index;
                    valueProp.serializedObject.ApplyModifiedProperties();
                    
                    base.Call();
                }
            }

            EditorGUIUtility.labelWidth = 28.0f;
            position.x += position.width - buttonWidth + 5.0f;
            position.width = fieldWidth + buttonWidth - 5.0f;
            EditorGUI.PropertyField(position, itemsProp.GetArrayElementAtIndex(i), new GUIContent("-"));
            EditorGUIUtility.labelWidth = labelWidth;

            position.y += EditorGUI.GetPropertyHeight(itemsProp.GetArrayElementAtIndex(i), true) + EditorGUIUtility.standardVerticalSpacing;
        }
        EditorGUI.indentLevel--;
       
        if (EditorGUI.EndChangeCheck())
        {
            itemsProp.serializedObject.ApplyModifiedProperties();
            base.Call();
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

        SerializedProperty valueObject = property.FindPropertyRelative("valueObject");

        if(valueObject.objectReferenceValue == null)
            return height;

        if (!property.isExpanded)
            return height;

        SerializedObject serializedValueObject = new SerializedObject(valueObject.objectReferenceValue);

        if (serializedValueObject == null)
            return height;

        SerializedProperty itemsProp = serializedValueObject.FindProperty("items");

        if(itemsProp.arraySize == 0)
        {
            height += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            return height;
        }

        for (int i = 0; i < itemsProp.arraySize; i++)
        {
            height += EditorGUI.GetPropertyHeight(itemsProp.GetArrayElementAtIndex(i), true) + EditorGUIUtility.standardVerticalSpacing;
        }

        return height;
    }
}