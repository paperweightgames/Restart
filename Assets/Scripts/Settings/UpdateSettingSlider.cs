using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    [RequireComponent(typeof(Slider))]
    public class UpdateSettingSlider : MonoBehaviour
    {
        [SerializeField] private string _setting;
        [SerializeField] private SettingType _settingType;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        public void SetSliderValue(float newValue)
        {
            _slider.value = newValue;
        }
        
        public void UpdateSetting()
        {
            // Set the setting.
            switch (_settingType)
            {
                case SettingType.Int:
                    PlayerPrefs.SetInt(_setting, Mathf.RoundToInt(_slider.value));
                    break;
                case SettingType.String:
                    PlayerPrefs.SetString(_setting, _slider.value.ToString(CultureInfo.InvariantCulture));
                    break;
                case SettingType.Float:
                    PlayerPrefs.SetFloat(_setting, _slider.value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}