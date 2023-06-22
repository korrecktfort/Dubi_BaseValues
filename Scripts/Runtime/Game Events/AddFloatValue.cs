using Dubi.GameEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    [CreateAssetMenu(menuName = "Dubi/Game Events/Override Float Value")]
    public class AddFloatValue : GameEvent
    {
        [SerializeField] float addValue = 0f;
        [SerializeField] FloatValue valueToOverride = null;

        public override bool CallEvent()
        {
            if (this.valueToOverride.IsConstant)
                return false;

            this.valueToOverride.Value += this.addValue;
            return true;
        }
    }
}
