using System;

namespace Quest.GameLogic
{
    public interface IQuestCondition
    {
        public void SetCondition(Func<bool> condition);
    }
}