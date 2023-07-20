using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(GameObjectSelection), true)]
public class GameObjectSelectionValueDrawer : SelectionValueDrawer<GameObjectSelectionObject, GameObject>
{
}
