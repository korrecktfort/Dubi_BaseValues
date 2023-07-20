using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class TextureValue : GenericBaseValue<Texture, TextureObject, BaseValueUpdater>
    {
        public TextureValue(Texture value) : base(value)
        {
        }
    }
}