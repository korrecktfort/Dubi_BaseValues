using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class Vector3Selection : Selection<Vector3, Vector3SelectionObject>
    {
        public Vector3Selection() : base()
        {
        }
    }
}