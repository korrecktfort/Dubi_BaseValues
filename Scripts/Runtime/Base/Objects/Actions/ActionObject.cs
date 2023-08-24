using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [CreateAssetMenu(menuName = "Dubi/Base Values/Base/Actions/Action", order = 20)]
    public class ActionObject : GenericValueObject<Action>
    {
    }

    public abstract class ActionObject<T> : GenericValueObject<Action<T>>
    {        
    }
}