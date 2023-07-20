using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class Texture2DReference : GenericBaseValue<Texture2D, Texture2DObject, BaseValueUpdater>
    {
        public Texture2DReference(Texture2D value) : base(value)
        {
        }
    }
}