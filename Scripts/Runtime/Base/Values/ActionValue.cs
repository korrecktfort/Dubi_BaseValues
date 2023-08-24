using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValue : GenericBaseValue<Action, ActionObject, BaseValueUpdater>
    {
        public ActionValue(Action value) : base(value)
        {
        }
    }
}
