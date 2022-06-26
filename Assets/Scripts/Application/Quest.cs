using Quest.Data;
using System;

namespace Quest.GameLogic
{
    public abstract class Quest
    {
        public abstract event Action<ScreenData.Data> OnCompleted;
        public abstract void TryComplete();
    }
}
