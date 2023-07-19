using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    [Serializable]
    public class StringSelectionValue : SelectionValue<string, StringSelectionObject>
    {
        public StringSelectionValue(int value) : base(value, true)
        {
        }
    }
}