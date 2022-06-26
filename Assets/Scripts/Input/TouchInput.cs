using System;
using UnityEngine;

namespace Quest.Input
{
    public sealed class TouchInput : MonoBehaviour, IInput
    {
        public event Action OnInputed;

        private void Update()
        {
            if (UnityEngine.Input.touchCount > 0)
            {
                OnInputed?.Invoke();
            }
        }
    }
}
