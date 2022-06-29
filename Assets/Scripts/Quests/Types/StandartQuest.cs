using System;

namespace Quest.GameLogic
{
    public sealed class StandartQuest : IQuest, IQuestCondition
    {
        public bool ContainsCompleteCallback => OnCompleted != null;

        public event Action OnCompleted;
        private event Func<bool> _condition;

        public void SetCondition(Func<bool> condition)
        {
            _condition = condition;
        }

        public void TryComplete()
        {
            var canComplete = _condition == null ? true : _condition();

            if (canComplete)
            {
                OnCompleted?.Invoke();
            }
        }
    }
}
