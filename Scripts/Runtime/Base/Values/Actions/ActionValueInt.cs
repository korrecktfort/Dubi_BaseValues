using System;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueInt : ActionValue<int>
    {
        public ActionValueInt() : base(null, true)
        {
        }

        public ActionValueInt(Action<int> value) : base(value)
        {
        }
    }
}
