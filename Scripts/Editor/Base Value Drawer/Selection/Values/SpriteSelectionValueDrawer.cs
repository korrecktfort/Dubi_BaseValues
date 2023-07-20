using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(SpriteSelection), true)]
public class SpriteSelectionValueDrawer : SelectionValueDrawer<SpriteSelectionObject, Sprite>
{
}
