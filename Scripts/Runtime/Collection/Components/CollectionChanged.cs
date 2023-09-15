using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    public abstract class CollectionChanged<T, U> : MonoBehaviour where T : BaseValue<U[]>
    {
        [SerializeField] T collection = default;
        [SerializeField] UnityEvent<U[]> onCollectionChanged = default;

        [SerializeField] BoolValue silent = null;
        [SerializeField] BoolValue late = null;

        private void OnEnable()
        {
            if (this.silent.Value)
            {
                if (this.late.Value)
                {
                    this.collection.RegisterCallbackLateSilent(OnCollectionChanged);
                }
                else
                {
                    this.collection.RegisterCallbackSilent(OnCollectionChanged);
                }
            }
            else
            {
                if (this.late.Value)
                {
                    this.collection.RegisterCallbackLate(OnCollectionChanged);
                }
                else
                {
                    this.collection.RegisterCallback(OnCollectionChanged);
                }
            }
        }

        private void OnDisable()
        {
            this.collection.DeregisterCallback(OnCollectionChanged);
        }

        void OnCollectionChanged(U[] collection)
        {
            this.onCollectionChanged?.Invoke(collection);
        }
    }
}