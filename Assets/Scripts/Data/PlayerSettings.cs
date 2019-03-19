using UnityEngine;
using UnityEngine.UI;

namespace Data
{
	public class PlayerSettings : MonoBehaviour
	{
		[SerializeField] private float[] settings = {
			2, // Horizontal Sensitivity.
			2, // Vertical Sensitivity.
			60, // Fov.
			.8f, // Master Volume.
			1, // Music Volume.
			1 // SFX Volume.
		};

		[SerializeField] private Slider[] sliders;

		private void Awake()
		{
			// Check if the settings already exist.
			if (PlayerPrefs.HasKey("Horizontal Sensitivity")) LoadSettings();
			else
			{
				SaveSettings();
				LoadSettings();
			}
		}

		public void SaveSettings()
		{
			PlayerPrefs.SetFloat("Horizontal Sensitivity", settings[0]);
			PlayerPrefs.SetFloat("Vertical Sensitivity", settings[1]);
			PlayerPrefs.SetFloat("FOV", settings[2]);
			PlayerPrefs.SetFloat("Master Volume", settings[3]);
			PlayerPrefs.SetFloat("Music Volume", settings[4]);
			PlayerPrefs.SetFloat("SFX Volume", settings[5]);
			PlayerPrefs.Save();
		}

		public void LoadSettings()
		{
			settings[0] = PlayerPrefs.GetFloat("Horizontal Sensitivity");
			settings[1] = PlayerPrefs.GetFloat("Vertical Sensitivity");
			settings[2] = PlayerPrefs.GetFloat("FOV");
			settings[3] = PlayerPrefs.GetFloat("Master Volume");
			settings[4] = PlayerPrefs.GetFloat("Music Volume");
			settings[5] = PlayerPrefs.GetFloat("SFX Volume");
		}

		public float GetSettingValue(int valueIndex)
		{
			return settings[valueIndex];
		}

		public void SetSettingsValue(int sliderIndex)
		{
			settings[sliderIndex] = sliders[sliderIndex].value;
		}
	}
}
