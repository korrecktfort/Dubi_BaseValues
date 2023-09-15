using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dubi.BaseValues
{
    public abstract class Collection<T> : BaseValueObject<T[]>
    {        
        public List<T> List
        {
            get => base.value.ToList();
            set
            {
                base.value = value.ToArray();
                base.OnValueChanged();
            }
        }

        public T[] Array {
            get => base.value;

            set
            {
                base.value = value;
                base.OnValueChanged();
            }
        }


        /// <summary>
        /// Adds item to the list, if denyContaining is true, it will not add the item if it already exists in the list
        /// </summary>
        /// <param name="item"></param>
        /// <param name="denyContaining"></param>
        public void Add(T item, bool denyContaining = true)
        {
            if (denyContaining && base.value.Contains(item))
                return;

            this.List.Add(item);

            base.OnValueChanged();
        }

        public void Remove(T item)
        {
            this.List.Remove(item);

            base.OnValueChanged();
        }
    }
}