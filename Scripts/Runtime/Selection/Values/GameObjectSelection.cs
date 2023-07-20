using System;
using UnityEngine;

namespace Dubi.BaseValues
{
    [Serializable]
    public class GameObjectSelection : Selection<GameObject, GameObjectSelectionObject>
    {
        public GameObjectSelection() : base()
        {
        }
    }
}