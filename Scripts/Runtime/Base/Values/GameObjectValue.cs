using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class GameObjectValue : GenericBaseValue<GameObject, GameObjectObject, BaseValueUpdater>
    {
        public GameObjectValue(GameObject value) : base(value)
        {
        }
    }
}