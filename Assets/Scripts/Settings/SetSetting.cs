using System;
using UnityEngine;

namespace Settings
{
    public class SetSetting : MonoBehaviour
    {
        [SerializeField] private string _setting;
        [SerializeField] private string _value;
        [SerializeField] private SettingType _settingType;
        
        public void UpdateSetting()
        {
            // Set the setting.
            switch (_settingType)
            {
                case SettingType.Int:
                    PlayerPrefs.SetInt(_setting, int.Parse(_value));
                    break;
                case SettingType.String:
                    PlayerPrefs.SetString(_setting, _value);
                    break;
                case SettingType.Float:
                    PlayerPrefs.SetFloat(_setting, float.Parse(_value));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}