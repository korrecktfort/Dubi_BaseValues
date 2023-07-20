using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class MaterialSelection : Selection<Material, MaterialSelectionObject>
    {
        public MaterialSelection() : base()
        {
        }
    }
}