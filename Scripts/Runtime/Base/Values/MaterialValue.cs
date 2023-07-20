using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class MaterialValue : GenericBaseValue<Material, MaterialObject, BaseValueUpdater>
    {
        public MaterialValue(Material value) : base(value)
        {
        }
    }
}