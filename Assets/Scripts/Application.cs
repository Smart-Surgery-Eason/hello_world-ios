using Sirenix.OdinInspector;
using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
namespace Eason.HelloWorldIos
{
    public class Application : MonoBehaviour
    {
        [SerializeField] private ToggleButton _menuButton;
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _uiCamera;

        [SerializeField] private GameObject[] _activateGroup;
        [SerializeField] private GameObject[] _deactivateGroup;

        [Header("Hello World")]
        [SerializeField] private GameObject _menuRoot; 
        [SerializeField] private Button _logHelloWorldButton;
        [SerializeField] private Button _changeStatusButton;
        [SerializeField] private TextMeshProUGUI _statusText;
        [ShowInInspector, ReadOnly, NonSerialized] private bool _status;

        [Header("File")]
        [SerializeField] private TMP_InputField _textEditorInputField;
        [SerializeField] private TMP_InputField _textFilePathInputField;
        [SerializeField] private Button _loadTextButton;
        [SerializeField] private Button _saveButton;
        [SerializeField] private string _textFilePath;
        [ShowInInspector, ReadOnly, NonSerialized] private string _textEditorText;

        [Header("Video")]
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private TMP_InputField _videoPathInputField;
        [SerializeField] private Button _loadVideoButton;
        [SerializeField] private string _videoPath;

        [Header("Video360")]
        [SerializeField] private VideoPlayer _video360Player;
        [SerializeField] private TMP_InputField _video360PathInputField;
        [SerializeField] private Button _loadVideo360Button;
        [SerializeField] private string _video360Path;

        private void Awake()
        {
            _menuButton.toggle.AddListener(ToggleMenuButton);
            // Menu
            _textEditorInputField.text = _textEditorText;
            _textFilePathInputField.text = _textFilePath;
            _videoPathInputField.text = _videoPath;
            _video360PathInputField.text = _video360Path;

            _logHelloWorldButton.onClick.AddListener(LogHelloWorld);
            _changeStatusButton.onClick.AddListener(ChangeStatus);
            _textEditorInputField.onValueChanged.AddListener(TextEditorInputFieldValueChanged);
            _textFilePathInputField.onValueChanged.AddListener(FilePathInputFieldValueChanged);
            _loadTextButton.onClick.AddListener(LoadText);
            _saveButton.onClick.AddListener(SaveText);
            _loadVideoButton.onClick.AddListener(LoadVideo);

            _videoPathInputField.onValueChanged.AddListener(VideoPathInputFieldValueChanged);
            _loadVideo360Button.onClick.AddListener(LoadVideo360);
            _video360PathInputField.onValueChanged.AddListener(Video360PathInputFieldValueChanged);
        }

        private void Video360PathInputFieldValueChanged(string path)
        {
            _video360Path = path;
        }


        private void VideoPathInputFieldValueChanged(string path)
        {
            _videoPath = path;
        }

        private void ToggleMenuButton(bool active)
        {
            foreach (var go in _activateGroup)
            {
                go.SetActive(active);
            }
            foreach (var go in _deactivateGroup)
            {
                go.SetActive(!active);
            }
        }

        private void OnDestroy()
        {
            _logHelloWorldButton.onClick.RemoveListener(LogHelloWorld);
            _changeStatusButton.onClick.RemoveListener(ChangeStatus);
            _textEditorInputField.onValueChanged.RemoveListener(TextEditorInputFieldValueChanged);
            _textFilePathInputField.onValueChanged.RemoveListener(FilePathInputFieldValueChanged);
            _loadTextButton.onClick.RemoveListener(LoadText);
            _saveButton.onClick.RemoveListener(SaveText);
            _loadVideoButton.onClick.RemoveListener(LoadVideo);

            _videoPathInputField.onValueChanged.RemoveListener(VideoPathInputFieldValueChanged);
            _loadVideo360Button.onClick.RemoveListener(LoadVideo360);
            _video360PathInputField.onValueChanged.RemoveListener(Video360PathInputFieldValueChanged);
        }

        private void TextEditorInputFieldValueChanged(string text)
        {
            _textEditorText = text;
        }

        private void FilePathInputFieldValueChanged(string text)
        {
            _textFilePath = text;
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

        private void LoadText()
        {
            var path = Path.Combine(UnityEngine.Application.persistentDataPath, _textFilePath);
            if (!File.Exists(path))
            {
                _statusText.text = "File Not Found.";
                return;
            }
            _textEditorText = File.ReadAllText(path);
            _textEditorInputField.text = _textEditorText;
        }
        private void SaveText()
        {
            var path = Path.Combine(UnityEngine.Application.persistentDataPath, _textFilePath);
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                _statusText.text = "Folder Not Found.";
            }
            File.WriteAllText(path, _textEditorText);
        }
        private void LoadVideo()
        {
            var path = Path.Combine(UnityEngine.Application.persistentDataPath, _videoPath);
            if(!File.Exists(path))
            {
                _statusText.text = "File Not Found.";
            }
            _videoPlayer.url = path;
            _videoPlayer.Play();
        }

        private void LoadVideo360()
        {
            var path = Path.Combine(UnityEngine.Application.persistentDataPath, _video360Path);
            if (!File.Exists(path))
            {
                _statusText.text = "File Not Found.";
            }
            _video360Player.url = path;
            _video360Player.Play();
        }
    }

}