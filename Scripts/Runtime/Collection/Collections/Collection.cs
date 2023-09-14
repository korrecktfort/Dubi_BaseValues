using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dubi.BaseValues
{
    public abstract class Collection<T> : ScriptableObject, BaseValue<List<T>>
    {        
        public List<T> List
        {
            get => this.list;
            set
            {
                this.list = value;
                OnCollectionChanged();
            }
        }

        public T[] Array {
            get => this.list.ToArray();

            set
            {
                this.list = value.ToList();
            }
        }

        [SerializeField] List<T> list = new List<T>();

        [NonSerialized] Action onValueChangedNoType = null;
        [NonSerialized] Action<List<T>> onValueChanged = null;
        [NonSerialized] UpdateType updateType = UpdateType.Immediate;
        [NonSerialized] BaseValueUpdater updater = null;

        /// <summary>
        /// Adds item to the list, if denyContaining is true, it will not add the item if it already exists in the list
        /// </summary>
        /// <param name="item"></param>
        /// <param name="denyContaining"></param>
        public void Add(T item, bool denyContaining = true)
        {
            if (denyContaining && this.list.Contains(item))
                return;

            this.list.Add(item);

            OnCollectionChanged();
        }

        public void Remove(T item)
        {
            this.list.Remove(item);

            OnCollectionChanged();
        }

        void OnCollectionChanged()
        {
            switch (this.updateType)
            {
                case UpdateType.Immediate:
                    Call();
                    break;
                case UpdateType.LateUpdate:
                    this.updater?.Register(this.updateType, this);
                    break;
            }
        }

        void RegisterUpdater()
        {
            if (this.updater != null)
                return;

            this.updater = BaseValueUpdater.Instance;
        }

        public void RegisterCallback(params Action[] actions)
        {
            RegisterCallbackSilent(actions);
            
            Call();
        }

        public void RegisterCallback(params Action<List<T>>[] actions)
        {
            RegisterCallbackSilent(actions);

            Call();
        }

        public void RegisterCallbackSilent(params Action[] actions)
        {
            foreach(var action in actions)
            {
                this.onValueChangedNoType -= action;
                this.onValueChangedNoType += action;
            }

            this.updateType = UpdateType.Immediate;
        }

        public void RegisterCallbackSilent(params Action<List<T>>[] actions)
        {
            foreach(var action in actions)
            {
                this.onValueChanged -= action;
                this.onValueChanged += action;
            }

            this.updateType = UpdateType.Immediate;
        }

        public void RegisterCallbackLate(params Action[] actions)
        {
            RegisterCallbackLateSilent(actions);

            BaseValueUpdater.Instance.Register(this.updateType, this);
        }

        public void RegisterCallbackLate(params Action<List<T>>[] actions)
        {
            RegisterCallbackLateSilent(actions);

            BaseValueUpdater.Instance.Register(this.updateType, this);
        }

        public void RegisterCallbackLateSilent(params Action[] actions)
        {
            RegisterUpdater();

            foreach(var action in actions)
            {
                this.onValueChangedNoType -= action;
                this.onValueChangedNoType += action;
            }

            this.updateType = UpdateType.LateUpdate;
        }

        public void RegisterCallbackLateSilent(params Action<List<T>>[] actions)
        {
            RegisterUpdater();

            foreach( var action in actions)
            {
                this.onValueChanged -= action;
                this.onValueChanged += action;
            }

            this.updateType = UpdateType.LateUpdate;
        }

        public void DeregisterCallback(params Action[] actions)
        {
            foreach(var action in actions)
                this.onValueChangedNoType -= action;
        }

        public void DeregisterCallback(params Action<List<T>>[] actions)
        {
            foreach(var action in actions)
                this.onValueChanged -= action;
        }

        public void Call()
        {
            this.onValueChanged?.Invoke(this.list);
            this.onValueChangedNoType?.Invoke();             
        }

        public void CheckValueObjectChange()
        {            
        }

        public void CheckUseScriptableObject()
        {            
        }
    }
}