using System;
using System.Collections;
using System.Collections.Generic;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValue : GenericBaseValue<Action, ActionObject, BaseValueUpdater>
    {
        public ActionValue(Action value) : base(value, true)
        {
        }
    }

    [System.Serializable]
    public abstract class ActionValue<T> : GenericBaseValue<Action<T>, ActionObject<T>, BaseValueUpdater>
    {
        protected ActionValue(Action<T> value) : base(value, true)
        {
        }
    }
}
