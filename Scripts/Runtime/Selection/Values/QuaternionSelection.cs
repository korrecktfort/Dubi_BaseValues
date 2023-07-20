using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class QuaternionSelection : Selection<Quaternion, QuaternionSelectionObject>
    {
        public QuaternionSelection() : base()
        {
        }
    }
}