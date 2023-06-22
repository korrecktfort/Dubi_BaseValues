using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    [System.Serializable]
    public class SpriteReference : GenericBaseValue<Sprite, SpriteReferenceObject, BaseValueUpdater>
    {
        public SpriteReference(Sprite value) : base(value)
        {
        }
    }
}