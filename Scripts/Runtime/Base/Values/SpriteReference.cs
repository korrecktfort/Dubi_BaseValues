using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class SpriteReference : GenericBaseValue<Sprite, SpriteObject, BaseValueUpdater>
    {
        public SpriteReference(Sprite value) : base(value)
        {
        }
    }
}