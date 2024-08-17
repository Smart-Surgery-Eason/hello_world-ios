using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Eason.HelloWorldIos
{
    public class SliderValueUI : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _value;

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(OnValueChanged);
        }
        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(OnValueChanged); 
        }

        private void OnValueChanged(float value)
        {
            _value.text = value.ToString(".00");
        }
    }

}