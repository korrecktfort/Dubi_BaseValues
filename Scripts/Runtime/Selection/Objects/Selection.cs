using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public abstract class Selection<T, U> : BaseValueObject<T> where U : Collection<T>
    {
        public List<T> List { get =>  this.collection.List; set => this.collection.List = value; }
        public T[] Array { get => this.collection.Array; set => this.collection.Array = value; }

        public int SelectionIndex
        {
            get => this.selectionIndex;
            set
            {
                if (this.selectionIndex == value)
                    return;

                this.selectionIndex = value;
                base.value = this.collection.List[value];

                OnValueChanged();
            }
        }

        [SerializeField] int selectionIndex = 0;
        [SerializeField] U collection;        
    }
}
