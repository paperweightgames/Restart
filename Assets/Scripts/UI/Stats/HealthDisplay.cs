using Player.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Stats {
	public class HealthDisplay : MonoBehaviour
	{
		[SerializeField] private PlayerHealth healthScript;
		[SerializeField] private Slider healthSlider;

		private void Update()
		{
			var healthDecimal = healthScript.GetCurrentHealth() / healthScript.GetMaxHealth();
			healthSlider.value = healthDecimal;
		}
	}
}
