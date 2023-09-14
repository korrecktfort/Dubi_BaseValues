using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Dubi.BaseValues
{
    public abstract class GenericValueObject<T> : BaseValueObject<T>
    {
        public T Value { get => base.value; set => base.value = value; }

        public bool ConstantValue => this.constantValue;

        [SerializeField] bool constantValue;
    }
}