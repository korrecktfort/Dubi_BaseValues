using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [CreateAssetMenu(menuName = "Dubi/Base Values/Base/Actions/Action", order = 20)]
    public class ActionObject : GenericValueObject<Action>
    {
        [NonSerialized] public new Action value;
    }

    public abstract class ActionObject<T> : GenericValueObject<Action<T>>
    {
        [NonSerialized] public new Action<T> value;

        public void Invoke(T value)
        {
            base.value?.Invoke(value);
        }
    }

}