using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [CreateAssetMenu(menuName = "Dubi/Base Values/Events/Call Event Object")]
    public class CallEventObject : ScriptableObject
    {
        [NonSerialized] Action actions = null;

        public void RegisterCallback(Action action)
        {
            actions -= action;
            actions += action;
        }

        public void DeregisterCallback(Action action)
        {
            actions -= action;
        }

        public void Invoke()
        {
            actions?.Invoke();
        }
    }
}