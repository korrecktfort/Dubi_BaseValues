using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class SpriteValue : GenericBaseValue<Sprite, SpriteObject, BaseValueUpdater>
    {
        public SpriteValue(Sprite value) : base(value)
        {
        }
    }
}