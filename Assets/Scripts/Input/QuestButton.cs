using Quest.Data;
using Quest.GameLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Quest.Input
{
    [RequireComponent(typeof(Button))]
    public sealed class QuestButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void Init(QuestSwitcher switcher, ScreenData.Data transition)
        {
            _button.onClick.AddListener(() => switcher.Switch(transition));
        }
    }
}
