using Quest.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quest.GameLogic
{
    public sealed class QuestSequence : IPusher, ICallbackReciever, IDisposable
    {
        private readonly QuestFactory _factory;
        private readonly QuestSwitcher _switcher;
        private IQuest _quest;
        private readonly List<IQuest> _quests;
        private readonly List<Action> _callbacks;

        public QuestSequence(QuestSwitcher switcher)
        {
            _switcher = switcher ?? throw new ArgumentNullException(nameof(switcher));
        }

        public void Dispose()
        {
            var questsWithCallback = _quests.Where(quest => quest.ContainsCompleteCallback);
            for (int i = 0; i < questsWithCallback.Count(); i++)
            {
                questsWithCallback.ElementAt(i).OnCompleted -= _callbacks[i];
            }
        }

        public IPusher Push<T>() where T : IQuest
        {
            _quest = _factory.Create<T>();
            _quests.Add(_quest);
            return this;
        }

        public ICallbackReciever WithCondition(Func<bool> condition)
        {
            var quest = _quest as IQuestCondition;
            quest.SetCondition(condition);
            return this;
        }

        public ICallbackReciever SetTransitions(ScreenData.Screen[] transitions)
        {
            _quest.OnCompleted += () => Switch(transitions);

            return this;
        }

        private void Switch(ScreenData.Screen[] transitions) => _switcher.Switch(transitions, _quest);

        public ICallbackReciever OnCompleted(Action completeCallback)
        {
            _quest.OnCompleted += completeCallback;
            _callbacks.Add(completeCallback);
            return this;
        }
    }
}
