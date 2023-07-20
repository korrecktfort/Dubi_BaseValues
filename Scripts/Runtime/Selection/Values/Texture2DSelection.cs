using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class Texture2DSelection : Selection<Texture2D, Texture2DSelectionObject>
    {
        public Texture2DSelection() : base()
        {
        }
    }
}