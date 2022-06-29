using Quest.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.GameLogic
{
    public sealed class EditorScreenData : MonoBehaviour
    {
        [SerializeField] private List<EditorScreen> _datas = new();
        private readonly ScreenFactory _factory = new();
        private readonly List<ScreenData.Screen> _screens = new();
        private IScreenStorage _screenStorage;

        public IEnumerable<ScreenData.Screen> Screens => _screens;

        public void Init(IScreenStorage screenStorage, QuestSwitcher questSwitcher)
        {
            if (questSwitcher is null)
            {
                throw new ArgumentNullException(nameof(questSwitcher));
            }

            _screenStorage = screenStorage ?? throw new ArgumentNullException(nameof(screenStorage));
            var loadData = _screenStorage.LoadAllData();
            if (loadData == null)
            {
                Add();
            }

            else
            {
                if (_screenStorage.TryLoad(out var lastSavedData))
                {
                    questSwitcher.Switch(new ScreenData.Screen[] { lastSavedData });
                }
                else
                {
                    throw new InvalidOperationException();
                }    
            }
        }

        public void Add()
        {
            for (int i = 0; i < _datas.Count; i++)
            {
                var screen = _factory.Create(_datas[i], _datas[i + 1].Transitions);
                _screens.Add(screen);
                _screenStorage.SaveData(screen);
            }
        }
    }

    [Serializable]
    public struct EditorScreen
    {
        [field: SerializeField, TextArea] public string Description { get; private set; }
        [field: SerializeField, TextArea] public string ChoiseDescription { get; private set; }
        [field: SerializeField] public Sprite Card { get; private set; }
        [field: SerializeField] public EditorScreen[] Transitions { get; private set; }
    }
}
