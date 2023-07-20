using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    public class CollectionObject<T> : ScriptableObject
    {        
        public List<T> List => this.list;

        public T[] Array => this.list.ToArray();

        public T Value => this.list.Count > 0 ? this.list[0] : default;

        [SerializeField] List<T> list = new List<T>();
    }
}