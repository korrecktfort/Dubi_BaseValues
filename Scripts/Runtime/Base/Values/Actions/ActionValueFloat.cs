using System;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueFloat : ActionValue<float>
    {
        public ActionValueFloat() : base(null, true)
        {

        }

        public ActionValueFloat(Action<float> value) : base(value)
        {
        }
    }
}
