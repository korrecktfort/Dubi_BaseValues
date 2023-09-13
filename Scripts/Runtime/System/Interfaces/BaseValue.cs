using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.BaseValues
{
    public interface BaseValue
    {
        public void Call();

        public void CheckValueObjectChange();

        public void CheckUseScriptableObject();
    }

    public interface BaseValue<T> : BaseValue
    {      
        public void RegisterCallback(params Action[] actions);

        public void RegisterCallback(params Action<T>[] actions);

        public void RegisterCallbackSilent(params Action[] actions);

        public void RegisterCallbackSilent(params Action<T>[] actions);
        public void RegisterCallbackLate(params Action[] actions);

        public void RegisterCallbackLate(params Action<T>[] actions);

        public void RegisterCallbackLateSilent(params Action[] actions);

        public void RegisterCallbackLateSilent(params Action<T>[] actions);

        public void DeregisterCallback(params Action[] actions);

        public void DeregisterCallback(params Action<T>[] actions);
    }

}