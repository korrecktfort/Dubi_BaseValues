using System;
using System.Collections;
using System.Collections.Generic;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValue : GenericBaseValue<Action, ActionObject, BaseValueUpdater>
    {
        public ActionValue() : base(null, true)
        {
        }

        public ActionValue(Action value, bool force = true) : base(value, force)
        {
        }
    }

    [System.Serializable]
    public abstract class ActionValue<T> : GenericBaseValue<Action<T>, ActionObject<T>, BaseValueUpdater>
    {
        public ActionValue() : base(null, true)
        {
        }

        public ActionValue(Action<T> value, bool force = true) : base(value, force)
        { 
        }
    }
}
