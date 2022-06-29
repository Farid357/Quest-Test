using Quest.Data;
using Quest.Input;
using System.Linq;
using UnityEngine;

namespace Quest.GameLogic
{
    public sealed class ApplicationStart : MonoBehaviour
    {
        [SerializeField] private EditorScreenData _editorScreenData;
        [SerializeField] private TouchInput _touchInput;
        [SerializeField] private ScreenSwitcherView _switcherView;
        private IQuestSwitcher _questSwitcher;

        private void Start()
        {
            var screenStorage = new ScreenStorage();
            _questSwitcher = new QuestSwitcher(screenStorage);
            _switcherView.Init(_questSwitcher as QuestSwitcher);
            _editorScreenData.Init(screenStorage, _questSwitcher as QuestSwitcher);
            for (int i = 0; i < _editorScreenData.Screens.Count() - 1; i++)
            {
                var screen = _editorScreenData.Screens.ElementAt(i);
                var sequnece = new QuestSequence(_questSwitcher as QuestSwitcher).Push<StandartQuest>().SetTransitions(screen.Transitions)
    .WithCondition(() => _touchInput.HasInputed);
            }
        }

        private void Update()
        {
            if (_questSwitcher.CurrentQuest is not null)
                _questSwitcher.CurrentQuest.TryComplete();
        }
    }
}
