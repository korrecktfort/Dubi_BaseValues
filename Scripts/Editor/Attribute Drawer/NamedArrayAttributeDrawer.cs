using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(NamedArrayAttribute))]
public class BoolValueArrayDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (this.attribute is NamedArrayAttribute namedArrayAttribute)
        {
            int pos = -1;
            int.TryParse(property.propertyPath.Split('[', ']')[1], out pos);
            label = (pos > -1) ? new GUIContent(namedArrayAttribute.names[pos]) : label;

            EditorGUI.PropertyField(position, property, label);
        }
        else
            EditorGUI.PropertyField(position, property, label);
    }
}
