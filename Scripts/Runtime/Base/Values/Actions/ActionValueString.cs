using System;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueString : ActionValue<string>
    {
        public ActionValueString(Action<string> value) : base(value)
        {
        }
    }
}
