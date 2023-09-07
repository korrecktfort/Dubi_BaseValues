using UnityEngine;

namespace Dubi.BaseValues
{
    [System.Serializable]
    public class Texture2DValue : GenericBaseValue<Texture2D, Texture2DObject, BaseValueUpdater>
    {
        public Texture2DValue(Texture2D value) : base(value)
        {
        }
    }
}