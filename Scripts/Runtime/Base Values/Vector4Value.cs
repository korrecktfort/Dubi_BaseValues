using System.Collections;
using UnityEngine;

namespace Rubi.BaseValues
{
    [System.Serializable]
    public class Vector4Value : GenericBaseValue<Vector4, Vector4ValueObject, BaseValueUpdater>
    {
        public Vector4Value(Vector4 value) : base(value)
        {
        }
    }
}