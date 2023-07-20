using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class StringValue : GenericBaseValue<string, StringObject, BaseValueUpdater>
    {
        public StringValue(string value) : base(value)
        {
        }
    }
}