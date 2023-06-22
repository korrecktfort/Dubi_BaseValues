using UnityEngine;

namespace Rubi.BaseValues
{
    [System.Serializable]
    public class Texture2DReference : GenericBaseValue<Texture2D, Texture2DReferenceObject, BaseValueUpdater>
    {
        public Texture2DReference(Texture2D value) : base(value)
        {
        }
    }
}