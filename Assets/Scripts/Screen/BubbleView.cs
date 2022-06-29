using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quest.GameLogic
{
    public sealed class BubbleView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _scaleCofficient = 2.5f;

        public Image Image { get; private set; }

        private void Awake()
        {
            Image = GetComponent<Image>();
        }

        public void Show(string text)
        {
            _text.text = text;
            var size = _text.textBounds.size;
            Image.transform.localScale += size * _scaleCofficient;
        }
    }
}
