using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(MaterialSelection), true)]
public class MaterialSelectionValueDrawer : SelectionValueDrawer<MaterialSelectionObject, Material>
{
}
