using System;
using System.Collections;
using UnityEngine;

namespace Rubi.BaseValues
{
    [Serializable]
    public abstract class SelectionValue<T, U> : GenericBaseValue<int, U, BaseValueUpdater> where U : GenericValueObject<int>
    {
        protected SelectionValue(int value, bool forceSO) : base(value, true)
        {
            
        }

        public void InjectSelectionObject(U selectionObject)
        {
            base.ValueObject = selectionObject;
        }
    }
}
