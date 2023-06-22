using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    [System.Serializable]
    public class MonoReference<T> : GenericBaseValue<T, GenericValueObject<T>, BaseValueUpdater>
    {
        public MonoReference(T value) : base(value)
        {
        }
    }
}
