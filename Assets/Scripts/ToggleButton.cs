using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace Eason.HelloWorldIos
{
    [RequireComponent(typeof(Button))]
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

        public void SetActive(bool active)
        {
            if (active == _active) return;
            _active = active;
            UpdateUI();
        }

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
            ButtonExtension.SetButtonPresentation(_button, _active ? _activePresentation : _deactivePresentation);
        }
    }

}