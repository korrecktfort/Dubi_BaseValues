using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(LayerMaskSelection), true)]
public class LayerMaskSelectionValueDrawer : SelectionValueDrawer<LayerMaskSelectionObject, LayerMask>
{
}
