using System.Collections.Generic;
using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

//[CustomPropertyDrawer(typeof(SelectionValue<,>), true)] 
public abstract class SelectionValueDrawer<T, U> : BaseValueDrawer<T> where T : SelectionObject<U>, new()
{
    protected override void DisplayValueField(Rect position, SerializedProperty property)
    {
        if (!base.baseProperty.FindPropertyRelative("useScriptableObject").boolValue)
            return;

        SerializedObject serializedValueObject = new SerializedObject(base.valueObject?.objectReferenceValue);

        if (serializedValueObject == null)
            return;

        SerializedProperty itemsProp = serializedValueObject.FindProperty("items");       

        EditorGUI.BeginChangeCheck();
        position.height = EditorGUIUtility.singleLineHeight;
        int value = EditorGUI.Popup(position, property.intValue, itemsProp.GetStringList().ToArray());

        if (EditorGUI.EndChangeCheck())
        {
            property.intValue = value;
            property.serializedObject.ApplyModifiedProperties();

            base.Call();
        }
    }
}
