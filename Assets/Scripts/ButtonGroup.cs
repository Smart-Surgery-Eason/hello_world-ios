using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace Eason.HelloWorldIos
{
    public class ButtonGroup : MonoBehaviour
    {
        public UnityEvent<int> buttonClick { get { return _buttonClick; } }
        public Button[] buttons
        {
            get
            {
                return _elements.Select(o => o.button).ToArray();
            }
        }
        public int count => _elements.Count;

        [Header("Settings")]
        [SerializeField] private bool _autoInitialize = false;
        [SerializeField] private List<string> _names = new List<string>();
        [SerializeField] private Button _buttonPrefab;
        [SerializeField] private UnityEvent<int> _buttonClick;

        [Header("States")]
        [SerializeField, ReadOnly, NonSerialized] private bool _initialized = false;
        [SerializeField, ReadOnly, NonSerialized] private readonly List<ButtonGroupElement> _elements = new List<ButtonGroupElement>();

        private void Clear()
        {
            for (int i = 0; i < _elements.Count; i++)
            {
                Destroy(_elements[i]?.gameObject);
            }
            _elements.Clear();
        }
        public void Initialize()
        {
            Clear();
            for (int i = 0; i < _names.Count; i++)
            {
                AddButton(_names[i]);
            }
            _initialized = true;
        }
        private void OnEnable()
        {
            if (_autoInitialize) Initialize();
        }
        private void OnDisable()
        {
            if (!_initialized) return;
            for (int i = 0; i < _elements.Count; i++)
            {
                _elements[i].buttonClick?.RemoveListener(OnButtonClick);
            }
            _initialized = false;
        }
        private void Start()
        {
            UpdateUI();
        }
        public ButtonGroupElement AddButton(string name)
        {
            var button = Instantiate(_buttonPrefab, transform);
            button.name = name;
            button.GetComponentInChildren<TextMeshProUGUI>().text = name;
            var element = button.AddComponent<ButtonGroupElement>();
            element.buttonClick?.AddListener(OnButtonClick);
            element.SetIndex(_elements.Count);
            _elements.Add(element);
            return element;
        }
        private void OnButtonClick(int index)
        {
            _buttonClick?.Invoke(index);
        }

        private void UpdateUI()
        {
        }
    }

}