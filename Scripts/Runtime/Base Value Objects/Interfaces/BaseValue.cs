using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    public interface BaseValue
    {
        public void Call();

        public void CheckValueObjectChange();

        public void CheckUseScriptableObject();
    }
}