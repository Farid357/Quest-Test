using Quest.Data;
using System;

namespace Quest.GameLogic
{
    public sealed class QuestSwitcher : IDisposable
    {
        private readonly Quest _quest;
        private readonly IScreenStorage _screenStorage;

        public QuestSwitcher(Quest quest, IScreenStorage screenStorage)
        {
            _quest = quest ?? throw new ArgumentNullException(nameof(quest));
            _screenStorage = screenStorage ?? throw new ArgumentNullException(nameof(screenStorage));
            _quest.OnCompleted += Switch;
        }

        public void Dispose() => _quest.OnCompleted -= Switch;

        public void Switch(ScreenData.Data data)
        {
            _screenStorage.SaveLastData(data);
        }
    }
}
