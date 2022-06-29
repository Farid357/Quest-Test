using UnityEngine;

namespace Quest.Input
{
    public sealed class TouchInput : MonoBehaviour, IInput
    {
        public bool HasInputed { get; private set; }

        private void Update()
        {
            HasInputed = UnityEngine.Input.GetMouseButtonDown(0);
        }
    }
}
