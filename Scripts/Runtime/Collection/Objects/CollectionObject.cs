using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    public class CollectionObject<T> : ScriptableObject
    {        
        [SerializeField] List<T> list = new List<T>();
    }
}