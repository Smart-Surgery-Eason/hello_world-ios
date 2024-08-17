using System;
using UnityEngine;
namespace Eason.HelloWorldIos
{

    [RequireComponent(typeof(ButtonGroupElement))]
    public class TabButton : MonoBehaviour
    {
        [SerializeField] private ButtonGroupElement _element;

        private void Reset()
        {
            _element = GetComponent<ButtonGroupElement>();
        }
        private void OnEnable()
        {
            _element = GetComponent<ButtonGroupElement>();
        }
        public void UpdateUI(TextBoxPresentation presentation)
        {
            _element.button.SetButtonPresentation(presentation);
        }
    }

}