using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
namespace Eason.HelloWorldIos
{

    [RequireComponent(typeof(ButtonGroup))]
    public class TabButtonGroup : MonoBehaviour
    {
        public UnityEvent<int, int> tabChanged { get => _tabChanged; set => _tabChanged = value; }

        [Header("Components")]
        [SerializeField] private ButtonGroup _buttonGroup;
        [SerializeField] private UnityEvent<int, int> _tabChanged;

        [Header("Prefabs")]

        [Header("Settings")]
        [SerializeField] private bool _autoInitialize = false;
        [SerializeField] private TextBoxPresentation _selected;
        [SerializeField] private TextBoxPresentation _unselected;
        [SerializeField, PropertyRange(0, nameof(maxIndex))] private int _initialIndex = 0;


        [Header("State")]
        [ShowInInspector, ReadOnly, NonSerialized] private bool _initialized = false;
        [ShowInInspector, ReadOnly, NonSerialized] private int _previousIndex = -1;
        [ShowInInspector, ReadOnly, NonSerialized] private int _currentIndex = -1;

        public int count => _buttonGroup.count;
        private int maxIndex => _buttonGroup.count -1;


        private void Reset()
        {
            _buttonGroup = GetComponent<ButtonGroup>();
        }
        public void Initialize()
        {
            _buttonGroup.Initialize();
            for (int i = 0; i < _buttonGroup.count; i++)
            {
                var tabButton = _buttonGroup.buttons[i].AddComponent<TabButton>();
                tabButton.UpdateUI(_unselected);
            }
            if(_previousIndex == -1)
            {
                _currentIndex = _initialIndex;
            }
            else
            {
                _previousIndex = -1;
            }
            UpdateUI();
            _initialized = true;
        }
        private void OnEnable()
        {
            _buttonGroup.buttonClick.AddListener(OnTabClick);
            if (!_autoInitialize) return;
            Initialize();
        }
        private void OnDisable()
        {
            _buttonGroup.buttonClick?.RemoveListener(OnTabClick);
            if (!_initialized) return;
            for (int i = 0; i < _buttonGroup.count; i++)
            {
                Destroy( _buttonGroup.buttons[i].GetComponent<TabButton>());
            }
            _initialized = false;
        }
        private void AddTab(string name)
        {
            var element = _buttonGroup.AddButton(name);
            element.AddComponent<TabButton>();
        }
        private void OnTabClick(int index)
        {
            if (_currentIndex == index) return;
            _previousIndex = _currentIndex;
            _currentIndex = index;
            _tabChanged?.Invoke(_previousIndex, _currentIndex);
            UpdateUI();
        }

        private void OnValidate()
        {
            if (UnityEngine.Application.isPlaying) return;
            //OnTabClick(initialIndex);
        }
        private void UpdateUI()
        {
            if (_currentIndex == _previousIndex) return;
            if(_previousIndex != -1)
            {
                _buttonGroup.buttons[_previousIndex].GetComponent<TabButton>().UpdateUI(_unselected);
            }
            if(_currentIndex != -1)
            {
                _buttonGroup.buttons[_currentIndex].GetComponent<TabButton>().UpdateUI(_selected);
            }
            _previousIndex= _currentIndex;

        }


    }

}