using Quest.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.GameLogic
{
    public sealed class EditorScreenData : MonoBehaviour
    {
        [SerializeField] private List<EditorData> _datas = new();
        [SerializeField] private ScreenSwitcherView _switcherView;
        private readonly IScreenStorage _screenStorage = new ScreenStorage();
        private readonly DataFactory _factory = new();

        private void Start()
        {
            var loadData = _screenStorage.LoadAllData();
            if (loadData == null)
            {
                Add();
            }

            else
            {
                if (_screenStorage.TryLoad(out var lastSavedData))
                {
                    _switcherView.Show(lastSavedData);
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
                var data = _factory.Create(_datas[i], _datas[i + 1]);
                _screenStorage.SaveData(data);
            }
        }
    }

    [Serializable]
    public struct EditorData
    {
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public string ChoiseDescription { get; private set; }
        [field: SerializeField] public Sprite Card { get; private set; }
        [field: SerializeField] public ScreenData.Data Transition { get; private set; }
    }

    public sealed class QuestSequence : ICallbackReciever, IDisposable
    {

        private readonly QuestFactory _factory;
        private Quest _quest;
        private event Action _callback;

        public QuestSequence(QuestSwitcher switcher)
        {
           
        }

        public void Dispose() => _callback -= _quest.TryComplete;

        public IPusher Push<T>() where T : Quest
        {
            var t = Activator.CreateInstance(typeof(T));
            _quest = _factory.Create((Quest)t);
            //IDisposable disposable = new QuestSwitcher(_quest,);
            return this;
        }

        public IPusher When(Action callback)
        {
            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
            _callback += _quest.TryComplete;
            return this;
        }

        public IPusher WithCondition(Func<bool> condition)
        {
            var standartQuest = _factory.TryCreate(_quest);
            standartQuest.SetCondition(condition);
            return this;
        }

        public IPusher WithTransition(ScreenData.Data transition)
        {
            var standartQuest = _factory.TryCreate(_quest);
            standartQuest.SetTransition(transition);
            return this;
        }
    }

    public interface IPusher
    {
        public IPusher Push<T>() where T : Quest;
    }

    public interface ICallbackReciever : IPusher
    {
        public IPusher When(Action callback);
        public IPusher WithCondition(Func<bool> condition);
    }
}
