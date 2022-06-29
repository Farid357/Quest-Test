using Quest.Data;
using Quest.GameLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quest.Input
{
    [RequireComponent(typeof(Button))]
    public sealed class QuestButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _choiseText;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void Init(QuestSwitcher switcher, ScreenData.Screen[] transitions)
        {
            var next = 0;
            _choiseText.text = transitions[next].ChoiseDescription;
            _button.onClick.AddListener(() => switcher.Switch(transitions));
        }
    }
}
