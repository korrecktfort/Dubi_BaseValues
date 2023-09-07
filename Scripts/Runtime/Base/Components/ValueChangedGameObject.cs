using UnityEngine;
using UnityEngine.Events;

namespace Dubi.BaseValues
{
    // game object
    public class ValueChangedGameObject : MonoBehaviour
    {
        [SerializeField] GameObjectValue gameObjectValue = null;
        [SerializeField] UnityEvent<GameObject> onValueChanged = null;

        private void OnEnable()
        {
            this.gameObjectValue.RegisterCallback(SendValue);
        }

        private void OnDisable()
        {
            this.gameObjectValue.DeregisterCallback(SendValue);
        }

        public void SendValue(GameObject value)
        {
            this.onValueChanged?.Invoke(value);
        }
    }


}