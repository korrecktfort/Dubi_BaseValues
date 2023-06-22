using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubi.BaseValues
{
    public class DominantBoolOverride : MonoBehaviour
    {
        [SerializeField] BoolValue dominantValue = null;
        [SerializeField] BoolValue toOverride = null;
        [SerializeField] BoolValue[] array = new BoolValue[0];

        private void OnEnable()
        {
            foreach (BoolValue value in this.array)
                value.RegisterCallbackSilent(CheckForDominance);

            CheckForDominance();
        }

        private void OnDisable()
        {
            foreach (BoolValue value in this.array)
                value.DeregisterCallback(CheckForDominance);
        }

        void CheckForDominance()
        {
            bool dominant = this.dominantValue.Value;
            foreach(BoolValue value in this.array)
            {
                if (value.Value != dominant)
                    continue;

                this.toOverride.Value = dominant;
                return;
            }

            this.toOverride.Value = !dominant;
        }
    }
}