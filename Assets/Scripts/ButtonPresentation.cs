using System;
using UnityEngine;
namespace Eason.HelloWorldIos
{
    [Serializable]
    public struct ButtonPresentation
    {
        [SerializeField] private Color _color;
        [SerializeField] private Color _backgroundColor;
        [SerializeField] private string _text;

        public string text { get => _text; set => _text = value; }
        public Color color { get => _color; set => _color = value; }
        public Color backgroundColor { get => _backgroundColor; set => _backgroundColor = value; }
    }
    [Serializable]
    public struct TextBoxPresentation
    {
        [SerializeField] private Color _color;
        [SerializeField] private Color _backgroundColor;
        public Color color { get => _color; set => _color = value; }
        public Color backgroundColor { get => _backgroundColor; set => _backgroundColor = value; }
    }
}