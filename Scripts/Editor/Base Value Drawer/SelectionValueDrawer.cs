using System.Collections.Generic;
using UnityEngine;
using Rubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(SelectionValue<,>), true)]
public class SelectionValueDrawer : BaseValueDrawer<GenericValueObject<int>>
{
    protected override void DisplayValueField(Rect position, SerializedProperty property)
    {
        SerializedObject serializedValueObject = new SerializedObject(base.valueObject.objectReferenceValue);
        SerializedProperty itemsProp = serializedValueObject.FindProperty("items");
        List<string> stringList = new List<string>();
        for (int i = 0; i < itemsProp.arraySize; i++)
        {
            switch (itemsProp.type)
            {
                case "string":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).stringValue);
                    break;
                case "int":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).intValue.ToString());
                    break;
                case "float":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).floatValue.ToString());
                    break;
                case "bool":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).boolValue.ToString());
                    break;
                case "Vector2":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).vector2Value.ToString());
                    break;
                case "Vector3":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).vector3Value.ToString());
                    break;
                case "Vector4":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).vector4Value.ToString());
                    break;
                case "Color":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).colorValue.ToString());
                    break;
                case "Rect":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).rectValue.ToString());
                    break;
                case "AnimationCurve":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).animationCurveValue.ToString());
                    break;
                case "Bounds":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).boundsValue.ToString());
                    break;
                case "Gradient":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).gradientValue.ToString());
                    break;
                case "Quaternion":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).quaternionValue.ToString());
                    break;
                case "Object":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).objectReferenceValue.ToString());
                    break;
                case "Enum":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).enumValueIndex.ToString());
                    break;
                case "Generic":
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).FindPropertyRelative("value").ToString());
                    break;
                default:
                    stringList.Add(itemsProp.GetArrayElementAtIndex(i).ToString());
                    break;
            }
        }

        EditorGUI.BeginChangeCheck();
        position.height = EditorGUIUtility.singleLineHeight;
        int value = EditorGUI.Popup(position, property.intValue, stringList.ToArray());

        if (EditorGUI.EndChangeCheck())
        {
            property.intValue = value;
            property.serializedObject.ApplyModifiedProperties();

            base.Call();
        }
    }
}
