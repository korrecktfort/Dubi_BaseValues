using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class TransformSelection : Selection<Transform, TransformSelectionObject>
    {
        public TransformSelection() : base()
        {
        }
    }
}