using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class RectSelection : Selection<Rect, RectSelectionObject>
    {
        public RectSelection() : base()
        {
        }
    }
}