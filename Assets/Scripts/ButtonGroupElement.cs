using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace Eason.HelloWorldIos
{
    public class ButtonGroupElement : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public Button button { get => _button; set => _button = value; }
        public UnityEvent<int> buttonClick { get => _buttonClick ; set => _buttonClick = value; }
        public void SetIndex(int index)
        {
            _index = index;
        }
        [SerializeField] private UnityEvent<int> _buttonClick = new UnityEvent<int>();

        [NonSerialized, ReadOnly, ShowInInspector] private int _index = -1;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        private void OnEnable()
        {
            button.onClick.AddListener(OnButtonClick);
        }
        private void OnDisable()
        {
            button.onClick?.RemoveListener(OnButtonClick);
        }
        private void OnButtonClick()
        {
            if (_index == -1) return;
            buttonClick.Invoke(_index);
        }
    }

}