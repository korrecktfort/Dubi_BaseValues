using Dubi.GameEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    [CreateAssetMenu(menuName ="Dubi/Game Events/Set Bool Value")]
    public class SetBoolValueEvent : GameEvent
    {
        [SerializeField, ShowOnSubAsset] BoolValue boolValue = null;
        public override bool CallEvent()
        {
            this.boolValue.Value = true;
            return true;
        }
    }
}
