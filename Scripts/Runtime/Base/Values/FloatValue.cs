using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class FloatValue : GenericBaseValue<float, FloatObject, BaseValueUpdater>
    {
        public FloatValue(float value) : base(value)
        {
        }

#if UNITY_EDITOR
        public static void ClearProperty(SerializedProperty property)
        {
            property.FindPropertyRelative("value").floatValue = 0.0f;

            property.FindPropertyRelative("useScriptableObject").boolValue = property.FindPropertyRelative("forceScriptableObject").boolValue;
            property.FindPropertyRelative("valueObject").objectReferenceValue = null;
            property.serializedObject.ApplyModifiedProperties();
        }
#endif
    }
}