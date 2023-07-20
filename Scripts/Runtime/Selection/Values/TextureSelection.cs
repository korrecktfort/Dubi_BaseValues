using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class TextureSelection : Selection<Texture, TextureSelectionObject>
    {
        public TextureSelection() : base()
        {
        }
    }
}