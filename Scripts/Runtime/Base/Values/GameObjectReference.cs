using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class GameObjectReference : GenericBaseValue<GameObject, GameObjectObject, BaseValueUpdater>
    {
        public GameObjectReference(GameObject value) : base(value)
        {
        }
    }
}