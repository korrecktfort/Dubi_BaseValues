using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(TextureSelection), true)]
public class TextureSelectionValueDrawer : SelectionValueDrawer<TextureSelectionObject, Texture>
{
}
