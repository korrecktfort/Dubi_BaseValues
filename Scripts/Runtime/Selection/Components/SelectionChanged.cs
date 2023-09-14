using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    public abstract class SelectionChanged<T, U> : MonoBehaviour where T : BaseValue<U>
    {
        [SerializeField] T selection = default;
    }
}