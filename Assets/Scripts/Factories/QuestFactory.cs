using System;

namespace Quest.GameLogic
{
    public sealed class QuestFactory
    {
        public Quest Create(Quest quest)
        {
            if (quest is StandartQuest)
            {
                return new StandartQuest();
            }

            throw new InvalidOperationException(quest.GetType().ToString());
        }

        public StandartQuest TryCreate(Quest quest)
        {
            if (quest is StandartQuest standartQuest)
                return standartQuest;
            else
                throw new InvalidCastException(nameof(quest));
        }
    }
}
