using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    [System.Serializable]
    public class StringValue : GenericBaseValue<string, StringValueObject, BaseValueUpdater>
    {
        public StringValue(string value) : base(value)
        {
        }
    }
}