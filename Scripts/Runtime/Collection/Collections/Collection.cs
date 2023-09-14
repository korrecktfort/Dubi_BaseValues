using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dubi.BaseValues
{

    public abstract class Collection<T> : BaseValueObject<List<T>>
    {        
        public List<T> List
        {
            get => this.list;
            set
            {
                this.list = value;
                base.OnValueChanged();
            }
        }

        public T[] Array {
            get => this.list.ToArray();

            set
            {
                this.list = value.ToList();
            }
        }

        [SerializeField] List<T> list = new List<T>();

        /// <summary>
        /// Adds item to the list, if denyContaining is true, it will not add the item if it already exists in the list
        /// </summary>
        /// <param name="item"></param>
        /// <param name="denyContaining"></param>
        public void Add(T item, bool denyContaining = true)
        {
            if (denyContaining && this.list.Contains(item))
                return;

            this.list.Add(item);

            base.OnValueChanged();
        }

        public void Remove(T item)
        {
            this.list.Remove(item);

            base.OnValueChanged();
        }
    }
}