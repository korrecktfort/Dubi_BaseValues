using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class ScriptableObjectSelection : Selection<ScriptableObject, ScriptableObjectSelectionObject>
    {
        public ScriptableObjectSelection() : base()
        {
        }
    }
}