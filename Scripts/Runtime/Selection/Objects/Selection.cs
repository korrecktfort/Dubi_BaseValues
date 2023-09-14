using System;
using System.Collections;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public abstract class Selection<T> : BaseValueObject<int>
    {
        public Collection<T> Collection => this.collection;

        [SerializeField] int selectionIndex = 0;
        [SerializeField] Collection<T> collection;
    }
}
