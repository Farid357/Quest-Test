using System;

namespace Quest.GameLogic
{
    public sealed class QuestFactory
    {
        public IQuest Create<T>() where T : IQuest
        {
            var quest = Activator.CreateInstance(typeof(T));
            if (quest is StandartQuest)
            {
                return new StandartQuest();
            }

            throw new InvalidOperationException(quest.GetType().ToString());
        }
    }
}
