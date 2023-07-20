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
        
        float fieldWidth = (width - buttonWidth * 2.0f) * 0.5f;

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

        using (new EditorGUIUtility.IconSizeScope(Vector2.one * EditorGUIUtility.singleLineHeight - Vector2.one * 9.0f))
        {
            if (GUI.Button(position, EditorGUIUtility.IconContent("d_pick")))
            {
                EditorGUIUtility.PingObject(collection.objectReferenceValue);
            }
        }

        position.x += buttonWidth;

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

[CustomPropertyDrawer(typeof(StringCollection))]
public class StringCollectionDrawer : CollectionDrawer<string, StringCollectionObject>
{
}

[CustomPropertyDrawer(typeof(AnimationClipCollection))]
public class AnimationClipCollectionDrawer : CollectionDrawer<AnimationClip, AnimationClipCollectionObject>
{
}

[CustomPropertyDrawer(typeof(AnimationCurveCollection))]
public class AnimationCurveCollectionDrawer : CollectionDrawer<AnimationCurve, AnimationCurveCollectionObject>
{
}

[CustomPropertyDrawer(typeof(AudioClipCollection))]
public class AudioClipCollectionDrawer : CollectionDrawer<AudioClip, AudioClipCollectionObject>
{
}

[CustomPropertyDrawer(typeof(BoolCollection))]
public class BoolCollectionDrawer : CollectionDrawer<bool, BoolCollectionObject>
{
}

[CustomPropertyDrawer(typeof(BoundsCollection))]
public class BoundsCollectionDrawer : CollectionDrawer<Bounds, BoundsCollectionObject>
{
}

[CustomPropertyDrawer(typeof(FloatCollection))]
public class FloatCollectionDrawer : CollectionDrawer<float, FloatCollectionObject>
{
}

[CustomPropertyDrawer(typeof(GameObjectCollection))]
public class GameObjectCollectionDrawer : CollectionDrawer<GameObject, GameObjectCollectionObject>
{
}

[CustomPropertyDrawer(typeof(GradientCollection))]
public class GradientCollectionDrawer : CollectionDrawer<Gradient, GradientCollectionObject>
{
}

[CustomPropertyDrawer(typeof(IntCollection))]
public class IntCollectionDrawer : CollectionDrawer<int, IntCollectionObject>
{
}

[CustomPropertyDrawer(typeof(LayerMaskCollection))]
public class LayerMaskCollectionDrawer : CollectionDrawer<LayerMask, LayerMaskCollectionObject>
{
}

[CustomPropertyDrawer(typeof(MaterialCollection))]
public class MaterialCollectionDrawer : CollectionDrawer<Material, MaterialCollectionObject>
{
}

[CustomPropertyDrawer(typeof(QuaternionCollection))]
public class QuaternionCollectionDrawer : CollectionDrawer<Quaternion, QuaternionCollectionObject>
{
}

[CustomPropertyDrawer(typeof(RectCollection))]
public class RectCollectionDrawer : CollectionDrawer<Rect, RectCollectionObject>
{
}

[CustomPropertyDrawer(typeof(ScriptableObjectCollection))]
public class ScriptableObjectCollectionDrawer : CollectionDrawer<ScriptableObject, ScriptableObjectCollectionObject>
{
}

[CustomPropertyDrawer(typeof(SpriteCollection))]
public class SpriteCollectionDrawer : CollectionDrawer<Sprite, SpriteCollectionObject>
{
}

[CustomPropertyDrawer(typeof(Texture2DCollection))]
public class Texture2DCollectionDrawer : CollectionDrawer<Texture2D, Texture2DCollectionObject>
{
}

[CustomPropertyDrawer(typeof(TextureCollection))]
public class TextureCollectionDrawer : CollectionDrawer<Texture, TextureCollectionObject>
{
}

[CustomPropertyDrawer(typeof(Vector2Collection))]
public class Vector2CollectionDrawer : CollectionDrawer<Vector2, Vector2CollectionObject>
{
}

[CustomPropertyDrawer(typeof(Vector3Collection))]
public class Vector3CollectionDrawer : CollectionDrawer<Vector3, Vector3CollectionObject>
{
}

[CustomPropertyDrawer(typeof(Vector4Collection))]
public class Vector4CollectionDrawer : CollectionDrawer<Vector4, Vector4CollectionObject>
{
}

