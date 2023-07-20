using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(Texture2DSelection), true)]
public class Texture2DSelectionValueDrawer : SelectionValueDrawer<Texture2DSelectionObject, Texture2D>
{
}
