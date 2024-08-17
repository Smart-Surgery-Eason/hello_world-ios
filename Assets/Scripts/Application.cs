using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        [SerializeField] private TMP_InputField _filePathInputField;
        [SerializeField] private Button _loadButton;
        [SerializeField] private TMP_InputField _textEditorInputField;
        [SerializeField] private Button _saveButton;


        [SerializeField] private bool _status;
        [SerializeField] private string _filePathText;
        [SerializeField] private string _textEditorText;

        private void Awake()
        {
            _logHelloWorldButton.onClick.AddListener(LogHelloWorld);
            _changeStatusButton.onClick.AddListener(ChangeStatus);


            _textEditorInputField.onValueChanged.AddListener(TextEditorInputFieldValueChanged);
            _textEditorInputField.text = _textEditorText;
            _filePathInputField.onValueChanged.AddListener(FilePathInputFieldValueChanged);
            _filePathInputField.text = _filePathText;
            _loadButton.onClick.AddListener(Load);
            _saveButton.onClick.AddListener(Save);
        }

        private void TextEditorInputFieldValueChanged(string text)
        {
            _textEditorText = text;
        }

        private void FilePathInputFieldValueChanged(string text)
        {
            _filePathText = text;
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

        private void Load()
        {
            var path = Path.Combine(UnityEngine.Application.persistentDataPath, _filePathText);
            if (!File.Exists(path))
            {
                _statusText.text = "File Not Found.";
                return;
            }
            _textEditorText = File.ReadAllText(path);
            _textEditorInputField.text = _textEditorText;
        }
        private void Save()
        {
            var path = Path.Combine(UnityEngine.Application.persistentDataPath, _filePathText);
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                _statusText.text = "Folder Not Found.";
            }
            File.WriteAllText(path, _textEditorText);
        }
    }

}