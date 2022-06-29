using Quest.Data;
using System;

namespace Quest.GameLogic
{
    public sealed class QuestSwitcher : IQuestSwitcher
    {
        private readonly IScreenStorage _screenStorage;

        public QuestSwitcher(IScreenStorage screenStorage)
        {
            _screenStorage = screenStorage ?? throw new ArgumentNullException(nameof(screenStorage));
        }


        public event Action<ScreenData.Screen[]> OnSwitched;

        public IQuest CurrentQuest { get; private set; }

        public void Switch(ScreenData.Screen[] screens, IQuest quest = default)
        {
            CurrentQuest = quest;
            var nextScreen = screens[0];
            _screenStorage.SaveLastScreen(nextScreen);
            OnSwitched?.Invoke(screens);
        }
    }
}
