using System;
using TMPro;
using UnityEngine.UI;
namespace Eason.HelloWorldIos
{
    [Flags]
    public enum ButtonPropertyFlags
    {
        None = 0,
        BackgroundColor = 1 << 0,
        Color = 1 << 1,
        Text = 1 << 2,
        All = BackgroundColor | Color | Text,
    }
    public static class ButtonExtension
    {
        public static void SetButtonPresentation(this Button button, TextBoxPresentation presentation)
        {
            button.GetComponent<Image>().color = presentation.backgroundColor;
            button.GetComponentInChildren<TextMeshProUGUI>().color = presentation.color;
        }
        public static void SetButtonPresentation(this Button button, ButtonPresentation presentation)
        {
            button.GetComponent<Image>().color = presentation.backgroundColor;
            button.GetComponentInChildren<TextMeshProUGUI>().color = presentation.color;
            button.GetComponentInChildren<TextMeshProUGUI>().text = presentation.text;
        }
        public static ButtonPresentation GetButtonPresentation(this Button button)
        {
            return new ButtonPresentation
            {
                backgroundColor = button.GetComponent<Image>().color,
                color = button.GetComponentInChildren<TextMeshProUGUI>().color,
                text = button.GetComponentInChildren<TextMeshProUGUI>().text
            };
        }
    }

}