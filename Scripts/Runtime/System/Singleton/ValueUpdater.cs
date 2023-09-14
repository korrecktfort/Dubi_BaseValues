using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Dubi.SingletonSpace;
using System;

namespace Dubi.BaseValues
{

    //[DefaultExecutionOrder(-1000)]
    public class ValueUpdater<T> : Singleton where T : MonoBehaviour
    {

        private static T instance;

        private static readonly object Lock = new object();

        [SerializeField] private bool persistent = true;

        Action lateCall = null;

        public static T Instance
        {
            get
            {
                if (Quitting)
                {
                    return null;
                }
                lock (Lock)
                {
                    if (instance != null)
                    {
                        return instance;
                    }

                    T[] instances = FindObjectsOfType<T>();
                    int count = instances.Length;
                    if (count > 0)
                    {
                        if (count == 1)
                        {
                            return instance = instances[0];
                        }

                        for (int i = count - 1; i > 0; i--)
                        {
                            Destroy(instances[i]);
                        }

                        return instance = instances[0];
                    }

                    instance = new GameObject("!" + typeof(T).ToString() + "- Singleton").AddComponent<T>();
                    return instance;
                }
            }
        }

        private void Awake()
        {
            if (this.persistent)            
                DontDestroyOnLoad(this.gameObject);            
        }      

        private void LateUpdate()
        {
            if (this.LocalQuitting)
                return;

            this.lateCall?.Invoke();
            this.lateCall = null;
        }     

        public void RegisterLate(Action callLate)
        {
            if (this.LocalQuitting)
                return;

            this.lateCall -= callLate;
            this.lateCall += callLate;
        }

        public void DeregisterLate(Action callLate)
        {
            if (this.LocalQuitting)
                return;

            this.lateCall -= callLate;
        }
    }    
}