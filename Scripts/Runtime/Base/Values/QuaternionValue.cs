using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class QuaternionValue : GenericBaseValue<Quaternion, QuaternionObject, BaseValueUpdater>
    {
        public QuaternionValue(Quaternion value) : base(value)
        {
        }

    }
}