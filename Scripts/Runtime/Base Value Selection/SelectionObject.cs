using System.Collections.Generic;

namespace Rubi.BaseValues
{
    public abstract class SelectionObject<T> : GenericValueObject<int>
    {
        public List<T> items = new List<T>();
    }
}
