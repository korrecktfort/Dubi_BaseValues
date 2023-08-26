using System;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueString : ActionValue<string>
    {
        public ActionValueString() : base(null, true)
        {

        }

        public ActionValueString(Action<string> value) : base(value)
        {
        }
    }
}
