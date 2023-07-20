using System.Collections;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class Vector4Value : GenericBaseValue<Vector4, Vector4Object, BaseValueUpdater>
    {
        public Vector4Value(Vector4 value) : base(value)
        {
        }
    }
}