using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class ColorSelection : Selection<Color, ColorSelectionObject>
    {
        public ColorSelection() : base()
        {
        }
    }
}