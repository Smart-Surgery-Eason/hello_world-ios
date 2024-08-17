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

        [Header("Menu")]
        [SerializeField] private GameObject _menuRoot; 
        [SerializeField] private Button _logHelloWorldButton;
        [SerializeField] private Button _changeStatusButton;
        [SerializeField] private TextMeshProUGUI _statusText;

        [SerializeField] private TMP_InputField _filePathInputField;
        [SerializeField] private Button _loadButton;
        [SerializeField] private TMP_InputField _textEditorInputField;
        [SerializeField] private Button _saveButton;
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
            _filePathInputField.text = _filePath;

            _logHelloWorldButton.onClick.AddListener(LogHelloWorld);
            _changeStatusButton.onClick.AddListener(ChangeStatus);
            _textEditorInputField.onValueChanged.AddListener(TextEditorInputFieldValueChanged);
            _filePathInputField.onValueChanged.AddListener(FilePathInputFieldValueChanged);
            _loadButton.onClick.AddListener(Load);
            _saveButton.onClick.AddListener(Save);
            _loadVideoButton.onClick.AddListener(LoadVideo);
        }

        private void ToggleMenuButton(bool active)
        {
            _menuRoot.SetActive(!active);
            _player.SetActive(active);
        }

        private void OnDestroy()
        {
            _logHelloWorldButton.onClick.RemoveListener(LogHelloWorld);
            _changeStatusButton.onClick.RemoveListener(ChangeStatus);
            _textEditorInputField.onValueChanged.RemoveListener(TextEditorInputFieldValueChanged);
            _filePathInputField.onValueChanged.RemoveListener(FilePathInputFieldValueChanged);
            _loadButton.onClick.RemoveListener(Load);
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