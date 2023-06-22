using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Dubi.Singleton;

namespace Rubi.BaseValues
{

    //[DefaultExecutionOrder(-1000)]
    public class ValueUpdater<T> : Singleton where T : MonoBehaviour
    {

        private static T instance;

        private static readonly object Lock = new object();

        [SerializeField] private bool persistent = true;

        BaseValue[] late = new BaseValue[0];

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
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }      

        private void LateUpdate()
        {
            Call(this.late);
            this.late = new BaseValue[0];
        }     

        void Call(BaseValue[] baseValues)
        {
            if (!Quitting && baseValues.Length > 0)            
                foreach (BaseValue baseValue in baseValues)                
                    baseValue.Call();
        }

        public void Register(UpdateType updateType, params BaseValue[] items)
        {
            if (!Quitting)
            {
                List<BaseValue> current = new List<BaseValue>();

                switch (updateType)
                {
                    case UpdateType.LateUpdate:
                        current = this.late.ToList();
                        break;
                }

                foreach (BaseValue item in items)                
                    if (!current.Contains(item))                    
                        current.Add(item);

                switch (updateType)
                {
                    case UpdateType.LateUpdate:
                        this.late = current.ToArray();
                        break;
                }
            }
        }

        public void Deregister(UpdateType updateType, params BaseValue[] items)
        {
            if (!Quitting)
            {
                List<BaseValue> current = new List<BaseValue>();

                switch (updateType)
                {
                    case UpdateType.LateUpdate:
                        current = this.late.ToList();
                        break;
                }

                foreach (BaseValue item in items)                
                    if (current.Contains(item))                    
                        current.Remove(item);                                      
                

                switch (updateType)
                {         
                    case UpdateType.LateUpdate:
                        this.late = current.ToArray();
                        break;
                }
            }
        }
    }    
}