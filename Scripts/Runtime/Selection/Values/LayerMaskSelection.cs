using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class LayerMaskSelection : Selection<LayerMask, LayerMaskSelectionObject>
    {
        public LayerMaskSelection() : base()
        {
        }
    }
}