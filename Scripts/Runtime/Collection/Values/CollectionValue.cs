using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class CollectionValue<T, U> where U : CollectionObject<T>
    {
#pragma warning disable
        [SerializeField] int selection = 0;
        [SerializeField] U collection = null;
#pragma warning restore
    }
}