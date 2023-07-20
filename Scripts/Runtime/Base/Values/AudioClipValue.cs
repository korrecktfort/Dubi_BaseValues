using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class AudioClipValue : GenericBaseValue<AudioClip, AudioClipObject, BaseValueUpdater>
    {
        public AudioClipValue(AudioClip value) : base(value)
        {
        }
    }
}