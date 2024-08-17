using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace Eason.HelloWorldIos
{
    [Serializable]
    public struct ButtonPresentation
    {
        [SerializeField] private string _text;
        [SerializeField] private Color _color;
        [SerializeField] private Color _backgroundColor;

        public string text { get => _text; set => _text = value; }
        public Color color { get => _color; set => _color = value; }
        public Color backgroundColor { get => _backgroundColor; set => _backgroundColor = value; }
    }
    public class ToggleButton : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _text;
        [Header("Settings")]
        [SerializeField] private ButtonPresentation _activePresentation;
        [SerializeField] private ButtonPresentation _deactivePresentation;
        [SerializeField] private UnityEvent<bool> _toggle;
        [Header("State")]
        [SerializeField] private bool _active;

        public UnityEvent<bool> toggle { get => _toggle; set => _toggle = value; }

        private void OnValidate()
        {
            UpdateUI();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Toggle);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(Toggle);
        }
        private void Toggle()
        {
            _active = !_active;
            _toggle.Invoke(_active);
            UpdateUI();
        }

        private void UpdateUI()
        {
            _text.text = _active ? _activePresentation.text : _deactivePresentation.text;
            _text.color = _active ? _activePresentation.color : _deactivePresentation.color;
            _button.GetComponent<Image>().color = _active ? _activePresentation.backgroundColor : _deactivePresentation.backgroundColor;
        }
    }

}