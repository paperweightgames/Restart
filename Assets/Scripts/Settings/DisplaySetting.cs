using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    [RequireComponent(typeof(Text))]
    public class DisplaySetting : MonoBehaviour
    {
        [SerializeField] private string _setting;
        [SerializeField] private string _formatting;
        [SerializeField] private SettingType _settingType;
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            string setting;
            
            // Get the setting.
            switch (_settingType)
            {
                case SettingType.Int:
                    setting = PlayerPrefs.GetInt(_setting, 0).ToString();
                    break;
                case SettingType.String:
                    setting = PlayerPrefs.GetString(_setting, "");
                    break;
                case SettingType.Float:
                    setting = PlayerPrefs.GetFloat(_setting, 0).ToString(CultureInfo.CurrentCulture);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            // Format it.
            _text.text = string.Format(_formatting, setting);
        }
    }
}