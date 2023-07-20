using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Dubi.BaseValues;
using System.Reflection;
using System;

public abstract class BaseValueDrawer<T> : PropertyDrawer where T : ScriptableObject
{    
    public SerializedProperty valueObject;
    public SerializedProperty baseProperty;
    float gapAfterButton = 10.0f;

    public override void OnGUI(Rect position, SerializedProperty baseProperty, GUIContent label)
    {
        this.baseProperty = baseProperty;

        SerializedProperty useScriptableObject = baseProperty.FindPropertyRelative("useScriptableObject");
        SerializedProperty forceBoolProp = baseProperty.FindPropertyRelative("forceScriptableObject");       

        EditorGUI.BeginProperty(position, label, baseProperty);        

        float x = position.x;
        float lineHeight = EditorGUIUtility.singleLineHeight;
        float rectWidth = position.width;
        float labelWidth = EditorGUIUtility.labelWidth;
        float dropDownWidth = EditorGUIUtility.singleLineHeight;
        float valueFieldWidthSO = ValueFieldWidth();
        float objectFieldWidthSO = rectWidth - labelWidth - dropDownWidth - valueFieldWidthSO;
        float noSOValueFieldWidth = rectWidth - labelWidth - dropDownWidth;

        position.height = lineHeight;
        position.width = labelWidth;
        EditorGUI.LabelField(position, baseProperty.displayName);

        EditorGUI.BeginDisabledGroup(forceBoolProp.boolValue);
        /// Mode Button
        position.x = x + labelWidth;
        position.width = dropDownWidth;

        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        EditorGUI.BeginChangeCheck();
        Vector2 iconSize = EditorGUIUtility.GetIconSize();
        EditorGUIUtility.SetIconSize(Vector2.one * dropDownWidth * 0.5f);
        useScriptableObject.boolValue = GUI.Toggle(position, useScriptableObject.boolValue, EditorGUIUtility.IconContent("d_pick"), "Button");
        EditorGUIUtility.SetIconSize(iconSize);

        if(EditorGUI.EndChangeCheck())
        {
            useScriptableObject.serializedObject.ApplyModifiedProperties();
            CheckUseScriptableObject();
        }
        EditorGUI.EndDisabledGroup();

        /// if using scriptable object
        position.x += dropDownWidth;
        position.width = noSOValueFieldWidth;
        if (useScriptableObject.boolValue)
        {
            this.valueObject = baseProperty.FindPropertyRelative("valueObject");

            if (this.valueObject.objectReferenceValue != null)
            {
                SerializedObject serializedObject = new SerializedObject(this.valueObject.objectReferenceValue);
                SerializedProperty valueProp = serializedObject.FindProperty("value");

                EditorGUI.BeginDisabledGroup(serializedObject.FindProperty("constantValue").boolValue);               
                position.width = valueFieldWidthSO;
                DisplayValueField(position, valueProp);
                position.x += valueFieldWidthSO;
                position.width = objectFieldWidthSO;
                EditorGUI.EndDisabledGroup();
            }          

            EditorGUI.BeginChangeCheck();
            EditorGUI.ObjectField(position, this.valueObject, typeof(T), GUIContent.none);
            if (EditorGUI.EndChangeCheck())
            {
                this.valueObject.serializedObject.ApplyModifiedProperties();
                CheckValueObjectChange();
            }
        }
        else /// using raw value
        {
            SerializedProperty rawValueProperty = baseProperty.FindPropertyRelative("value");
            DisplayValueField(position, rawValueProperty);
        }

        EditorGUI.indentLevel = indent;

        position.x = x;
        position.width = rectWidth;
        position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        DrawAdditionalFields(position, baseProperty);

        EditorGUI.EndProperty();
    }

    protected virtual void DisplayValueField(Rect position, SerializedProperty property)
    {
        EditorGUI.BeginChangeCheck();
        
        float labelWidth = EditorGUIUtility.labelWidth;
        EditorGUIUtility.labelWidth = gapAfterButton;
        EditorGUI.PropertyField(position, property, EditorGUIUtility.IconContent("d_Toolbar Minus@2x"), true);
        EditorGUIUtility.labelWidth = labelWidth;

        if (EditorGUI.EndChangeCheck())
        {
            property.serializedObject.ApplyModifiedProperties();
            Call();    
        }
    }
   
    public void ToEnd(ref Rect position, float gap = 5.0f)
    {
        position.x = position.x + position.width + gap;
    }

    public virtual void DrawAdditionalFields(Rect position, SerializedProperty baseProperty)
    {
    }

    public virtual float ValueFieldWidth()
    {
        return 100.0f;
    }

    protected void Call()
    {
        if (EditorApplication.isPlaying)
            GetTargetObject<BaseValue>(this.baseProperty.serializedObject.targetObject, this.baseProperty.propertyPath)?.Call();      
    }

    protected void CheckValueObjectChange()
    {
        if (EditorApplication.isPlaying)
            GetTargetObject<BaseValue>(this.baseProperty.serializedObject.targetObject, this.baseProperty.propertyPath)?.CheckValueObjectChange();
    }

    protected void CheckUseScriptableObject()
    {
        if (EditorApplication.isPlaying)
            GetTargetObject<BaseValue>(this.baseProperty.serializedObject.targetObject, this.baseProperty.propertyPath)?.CheckUseScriptableObject();
    }

    U GetTargetObject<U>(object target, string path) where U : class
    {            
        string name = path[(path.LastIndexOf(".") + 1)..];
        BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        if (!path.Contains("."))
            return (U)target.GetType().GetField(name, flags).GetValue(target);

        do
        {
            string p = path[..path.IndexOf(".")];
            target = target.GetType().GetField(p, flags).GetValue(target);

            if (target is Array)
            {
                Array array = target as Array;
                int s0 = path.IndexOf("[") + 1;
                int s1 = path.IndexOf("]");

                if (int.TryParse(path[s0..s1].ToString(), out int index))
                {
                    object baseValue = GetTargetObject<U>(array.GetValue(index), path[(path.LastIndexOf("]") + 2)..]);
                    
                    if (baseValue != null && baseValue is U value)
                        return value;
                }     
            }
            else
            {
                FieldInfo fieldInfo = target.GetType().GetField(name, flags);

                if (fieldInfo != null)
                {
                    object baseValue = fieldInfo.GetValue(target);
                    if (baseValue is U value)
                        return value;
                }                              
            }            

            path = path[(path.IndexOf(".") + 1)..];

        } while (path.Contains("."));

        return null;       
    }
}

public static class BaseValueHelper
{
    public static SerializedProperty GetValueProp(SerializedProperty baseValueProperty)
    {
        SerializedProperty valueObjectProperty = baseValueProperty.FindPropertyRelative("valueObject");
        if(baseValueProperty.FindPropertyRelative("useScriptableObject").boolValue && valueObjectProperty.objectReferenceValue != null)
        {
            SerializedObject serializedObject = new SerializedObject(valueObjectProperty.objectReferenceValue);
            return serializedObject.FindProperty("value");
        }

        return baseValueProperty.FindPropertyRelative("value");
    }

    public static List<string> GetStringList(this SerializedProperty itemsProp)
    {
        List<string> stringList = new List<string>();
        for (int i = 0; i < itemsProp.arraySize; i++)
        {
            SerializedProperty prop = itemsProp.GetArrayElementAtIndex(i);

            switch (prop.propertyType)
            {
                case SerializedPropertyType.String:
                    stringList.Add(prop.stringValue);
                    break;
                case SerializedPropertyType.Integer:
                    stringList.Add(prop.intValue.ToString());
                    break;
                case SerializedPropertyType.Float:
                    stringList.Add(prop.floatValue.ToString());
                    break;
                case SerializedPropertyType.Boolean:
                    stringList.Add(prop.boolValue.ToString());
                    break;
                case SerializedPropertyType.Vector2:
                    stringList.Add(prop.vector2Value.ToString());
                    break;
                case SerializedPropertyType.Vector3:
                    stringList.Add(prop.vector3Value.ToString());
                    break;
                case SerializedPropertyType.Vector4:
                    stringList.Add(prop.vector4Value.ToString());
                    break;
                case SerializedPropertyType.Color:
                    stringList.Add(prop.colorValue.ToString());
                    break;
                case SerializedPropertyType.Rect:
                    stringList.Add(prop.rectValue.ToString());
                    break;
                case SerializedPropertyType.AnimationCurve:
                    stringList.Add(prop.animationCurveValue.ToString());
                    break;
                case SerializedPropertyType.Bounds:
                    stringList.Add(prop.boundsValue.ToString());
                    break;
                case SerializedPropertyType.Gradient:
                    stringList.Add(prop.gradientValue.ToString());
                    break;
                case SerializedPropertyType.Quaternion:
                    stringList.Add(prop.quaternionValue.ToString());
                    break;
                case SerializedPropertyType.ObjectReference:
                    stringList.Add(prop.objectReferenceValue != null ? prop.objectReferenceValue.name.ToString()  : "null");
                    break;
                case SerializedPropertyType.Enum:
                    stringList.Add(prop.enumValueIndex.ToString());
                    break;              
                default:
                    stringList.Add(prop.type.ToString() + " " + i);
                    break;
            }
        }

        return stringList;
    }
}
