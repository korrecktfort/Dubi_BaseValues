using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    [System.Serializable]
    public class Vector3Value : GenericBaseValue<Vector3, Vector3ValueObject, BaseValueUpdater>
    {
        public Vector3Value(Vector3 value) : base(value)
        {
        }

#if UNITY_EDITOR
        public static void ClearProperty(UnityEditor.SerializedProperty property)
        {
            property.FindPropertyRelative("value").vector3Value = Vector3.zero;

            property.FindPropertyRelative("useScriptableObject").boolValue = property.FindPropertyRelative("forceScriptableObject").boolValue;
            property.FindPropertyRelative("valueObject").objectReferenceValue = null;
            property.serializedObject.ApplyModifiedProperties();
        }
#endif
    }
}