using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // scriptable object
    public class ValueChangedScriptableObject : MonoBehaviour
    {
        [SerializeField] ScriptableObjectValue scriptableObjectValue = null;
        [SerializeField] UnityEvent<ScriptableObject> onValueChanged = null;

        private void OnEnable()
        {
            this.scriptableObjectValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.scriptableObjectValue.DeregisterCallback(SendValue);
        }

        public void SendValue(ScriptableObject value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}