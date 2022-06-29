using System;

namespace Quest.GameLogic
{
    public interface IQuest
    {
        public abstract void TryComplete();
        public bool ContainsCompleteCallback { get; }

        public event Action OnCompleted;

    }
}
