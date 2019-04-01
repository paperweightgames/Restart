using Player.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Stats {
	public class HungerDisplay : MonoBehaviour
	{
		[SerializeField] private PlayerHunger hungerScript;
		[SerializeField] private Slider hungerSlider;

		private void Update()
		{
			var healthDecimal = hungerScript.GetCurrentHunger() / hungerScript.GetMaxHunger();
			hungerSlider.value = healthDecimal;
		}
	}
}
