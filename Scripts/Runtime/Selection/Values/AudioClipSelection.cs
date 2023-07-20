using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class AudioClipSelection : Selection<AudioClip, AudioClipSelectionObject>
    {
        public AudioClipSelection() : base()
        {
        }
    }
}