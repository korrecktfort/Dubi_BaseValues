using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class BoundsSelection : Selection<Bounds, BoundsSelectionObject>
    {
        public BoundsSelection() : base()
        {
        }
    }
}