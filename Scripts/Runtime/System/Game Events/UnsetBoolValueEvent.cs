using Dubi.GameEvents;
using UnityEngine;

namespace Dubi.BaseValues
{
    [CreateAssetMenu(menuName ="Dubi/Game Events/Unset Bool Value")]
    public class UnsetBoolValueEvent : GameEvent 
    {
        [SerializeField] BoolValue boolValue = null;

        public override bool CallEvent()
        {
            this.boolValue.Value = false;
            return true;
        }
    }
}
