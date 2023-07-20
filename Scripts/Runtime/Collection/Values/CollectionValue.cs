using System;
using System.Collections.Generic;
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

        public T SelectedValue => this.collection.Value;

        public T[] Array => this.collection?.Array;

        public List<T> List => this.collection?.List;
    }
}