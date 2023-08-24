using System;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class ActionValueFloat : ActionValue<float>
    {
        public ActionValueFloat(Action<float> value) : base(value)
        {
        }
    }
}
