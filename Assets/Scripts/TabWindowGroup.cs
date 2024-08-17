using Sirenix.OdinInspector;
using System;
using System.Linq;
using UnityEngine;
namespace Eason.HelloWorldIos
{
    public class TabWindowGroup : MonoBehaviour
    {
        [SerializeField, Required] private TabButtonGroup _tabButtonGroup;
        [ShowInInspector, NonSerialized, ReadOnly] private GameObject[] _tabWindows;

        private void OnEnable()
        {
            UpdateHierarchy();
            _tabButtonGroup.tabChanged.AddListener(OnTabChanged);
        }
        private void OnDisable()
        {
            _tabButtonGroup.tabChanged.RemoveListener(OnTabChanged);
        }
        private void OnTabChanged(int previous, int current)
        {
            UpdateHierarchy();
            if (previous >= 0 && previous < _tabButtonGroup.count)
            {
                _tabWindows[previous].SetActive(false);
            }
            if (current >= 0 && current < _tabButtonGroup.count)
            {
                _tabWindows[current].SetActive(true);
            }
        }
        [Button]
        private void UpdateHierarchy()
        {
            _tabWindows = new GameObject[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                _tabWindows[i] = transform.GetChild(i).gameObject;
            }
        }
    }

}