using UnityEngine;
using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(AudioClipSelection), true)]
public class AudioClipSelectionValueDrawer : SelectionValueDrawer<AudioClipSelectionObject, AudioClip>
{
}