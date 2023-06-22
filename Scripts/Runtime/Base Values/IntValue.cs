using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    [System.Serializable]
    public class IntValue : GenericBaseValue<int, IntValueObject, BaseValueUpdater>
    {
        public IntValue(int value) : base(value)
        {
        }
    }
}