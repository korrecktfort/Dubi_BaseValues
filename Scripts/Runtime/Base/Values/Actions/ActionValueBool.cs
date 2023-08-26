using System;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueBool : ActionValue<bool>
    {
        public ActionValueBool() : base(null, true)
        {
        }

        public ActionValueBool(Action<bool> value) : base(value)
        {
        }
    }
}
