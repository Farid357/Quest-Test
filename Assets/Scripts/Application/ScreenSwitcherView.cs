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
        private QuestSwitcher _questSwitcher;

        public void Init(QuestSwitcher questSwitcher)
        {
            _questSwitcher = questSwitcher ?? throw new ArgumentNullException(nameof(questSwitcher));
        }

        public void Show(ScreenData.Data data)
        {
            var texture = new Texture2D(4, 4);
            texture.LoadImage(data.Card);
            _backGround.sprite = Sprite.Create(texture, _backGround.rectTransform.rect, _backGround.rectTransform.pivot);
            if (data.ChoiseDescription != null)
            {
                var button = Instantiate(_prefab, _parent.transform);
                button.Init(_questSwitcher, data.Transition);
            }
        }
    }
}
