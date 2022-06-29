using Quest.Data;
using Quest.Input;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Quest.GameLogic
{
    public sealed class ScreenSwitcherView : MonoBehaviour
    {
        [SerializeField] private Image _backGround;
        [SerializeField] private Transform _parent;
        [SerializeField] private QuestButton _prefab;
        [SerializeField] private BubbleView _bubble;
        private QuestSwitcher _questSwitcher;

        public void Init(QuestSwitcher questSwitcher)
        {
            _questSwitcher = questSwitcher ?? throw new ArgumentNullException(nameof(questSwitcher));
            _questSwitcher.OnSwitched += Show;
        }

        public void Show(ScreenData.Screen[] screens)
        {
            Debug.Log("Log");
            var texture = new Texture2D(4, 4);
            var next = screens[0];
            texture.LoadImage(next.Card);
            _backGround.sprite = Sprite.Create(texture, _backGround.rectTransform.rect, _backGround.rectTransform.pivot);
            _bubble.Show(next.Description);
         
            if (next.ChoiseDescription != null)
            {
                for (int i = 1; i < screens.Length; i++)
                {
                    var button = Instantiate(_prefab, _parent.transform);
                    button.Init(_questSwitcher, screens[i].Transitions);
                }
            }
        }

        private void OnDisable() => _questSwitcher.OnSwitched -= Show;
    }
}
