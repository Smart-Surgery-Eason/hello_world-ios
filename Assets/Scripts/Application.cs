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

        [Header("File")]
        [SerializeField] private TMP_InputField _textFilePathInputField;
        [SerializeField] private Button _loadTextButton;
        [SerializeField] private Button _saveButton;
        [SerializeField] private TMP_InputField _textEditorInputField;

        [Header("Video")]
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private Button _loadVideoButton;


        [SerializeField] private bool _status;
        [SerializeField] private string _filePath;
        [SerializeField] private string _textEditorText;
        private void Awake()
        {
            _menuButton.toggle.AddListener(ToggleMenuButton);
            // Menu
            _textEditorInputField.text = _textEditorText;
            _textFilePathInputField.text = _filePath;

            _logHelloWorldButton.onClick.AddListener(LogHelloWorld);
            _changeStatusButton.onClick.AddListener(ChangeStatus);
            _textEditorInputField.onValueChanged.AddListener(TextEditorInputFieldValueChanged);
            _textFilePathInputField.onValueChanged.AddListener(FilePathInputFieldValueChanged);
            _loadTextButton.onClick.AddListener(Load);
            _saveButton.onClick.AddListener(Save);
            _loadVideoButton.onClick.AddListener(LoadVideo);
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
            _loadTextButton.onClick.RemoveListener(Load);
            _saveButton.onClick.RemoveListener(Save);
            _loadVideoButton.onClick.RemoveListener(LoadVideo);
        }

        private void TextEditorInputFieldValueChanged(string text)
        {
            _textEditorText = text;
        }

        private void FilePathInputFieldValueChanged(string text)
        {
            _filePath = text;
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
            var path = Path.Combine(UnityEngine.Application.persistentDataPath, _filePath);
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
            var path = Path.Combine(UnityEngine.Application.persistentDataPath, _filePath);
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                _statusText.text = "Folder Not Found.";
            }
            File.WriteAllText(path, _textEditorText);
        }
        private void LoadVideo()
        {
            var path = Path.Combine(UnityEngine.Application.persistentDataPath, _filePath);
            if(!File.Exists(path))
            {
                _statusText.text = "File Not Found.";
            }
            _videoPlayer.url = path;
            _videoPlayer.Play();

        }
    }

}