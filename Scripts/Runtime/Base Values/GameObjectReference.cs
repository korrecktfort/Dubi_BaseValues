using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    [System.Serializable]
    public class GameObjectReference : GenericBaseValue<GameObject, GameObjectReferenceObject, BaseValueUpdater>
    {
        public GameObjectReference(GameObject value) : base(value)
        {
        }
    }
}