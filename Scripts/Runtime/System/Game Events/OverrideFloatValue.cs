using Dubi.GameEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [CreateAssetMenu(menuName ="Dubi/Game Events/Override Float Value")]
    public class OverrideFloatValue : GameEvent
    {
        [SerializeField] float overrideValueTo = 0f;
        [SerializeField] FloatValue valueToOverride = null;

        public override bool CallEvent()
        {
            if (this.valueToOverride.IsConstant)
                return false;

            this.valueToOverride.Value = overrideValueTo;
            return true;
        }
    }
}
