using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Eason.HelloWorldIos
{
    public class Application : MonoBehaviour
    {
        [SerializeField] private Button _logHelloWorldButton;
        [SerializeField] private Button _changeStatusButton;
        [SerializeField] private TextMeshProUGUI _statusText;

        [SerializeField] private bool _status;

        private void Awake()
        {
            _logHelloWorldButton.onClick.AddListener(LogHelloWorld);
            _changeStatusButton.onClick.AddListener(ChangeStatus);
        }

        private void ChangeStatus()
        {
            _status = !_status;
            _statusText.text = _status ? "On" : "Off";
        }

        private void LogHelloWorld()
        {
            Debug.Log("Hello, World!");
        }
    }

}