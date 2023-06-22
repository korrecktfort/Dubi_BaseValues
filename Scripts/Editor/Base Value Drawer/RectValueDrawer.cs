using UnityEngine;
using Rubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(RectValue))]
public class RectValueDrawer : BaseValueDrawer<RectValueObject>
{
    public override float ValueFieldWidth()
    {
        return 150.0f;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        bool use = property.FindPropertyRelative("useScriptableObject").boolValue;
        bool usingObj = property.FindPropertyRelative("valueObject").objectReferenceValue != null;

        if (!use || (use && usingObj))
        {
            return EditorGUIUtility.singleLineHeight * 2.0f + EditorGUIUtility.standardVerticalSpacing;
        }
        
        return EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
    }
}
