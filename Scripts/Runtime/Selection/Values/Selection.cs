using System;
using System.Collections;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public abstract class Selection<T, U> : GenericBaseValue<int, U, BaseValueUpdater> where U : SelectionObject<T>
    {
        protected Selection() : base(0, true)
        {
            
        }

        public void InjectSelectionObject(U selectionObject)
        {
            base.ValueObject = selectionObject;
        }      

        public T GetValue(int index)
        {
            return base.ValueObject.items[index];
        }
    }
}
