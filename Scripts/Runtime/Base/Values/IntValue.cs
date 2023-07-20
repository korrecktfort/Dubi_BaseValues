using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class IntValue : GenericBaseValue<int, IntObject, BaseValueUpdater>
    {
        public IntValue(int value) : base(value)
        {
        }
    }
}