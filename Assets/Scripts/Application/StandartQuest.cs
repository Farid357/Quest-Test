using Quest.Data;
using System;

namespace Quest.GameLogic
{
    public sealed class StandartQuest : Quest
    {
        private ScreenData.Data _transition;
        private event Func<bool> _condition;

        public override event Action<ScreenData.Data> OnCompleted;

        public void SetTransition(ScreenData.Data transition)
        {
            if (_transition != null) throw new InvalidOperationException();
            _transition = transition ?? throw new ArgumentNullException(nameof(transition));
        }


        public void SetCondition(Func<bool> condition)
        {
            _condition = condition ?? throw new ArgumentNullException(nameof(condition));
        }

        public override void TryComplete()
        {
            var canComplete = _condition == null ? true : _condition();

            if (canComplete)
            {
                OnCompleted?.Invoke(_transition);
            }
        }
    }
}
