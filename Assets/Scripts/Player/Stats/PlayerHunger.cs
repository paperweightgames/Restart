using UnityEngine;

namespace Player.Stats {
	public class PlayerHunger : MonoBehaviour
	{
		[SerializeField] private float maxHunger;
		[SerializeField] private float currentHunger;
		[SerializeField] private float hungerRate;
		[SerializeField] private float damageRate;
		[SerializeField, Header("References")] private PlayerHealth playerHealth;

		public float GetMaxHunger()
		{
			return maxHunger;
		}

		public float GetCurrentHunger()
		{
			return currentHunger;
		}

		private void Update()
		{
			// Reduce the hunger.
			currentHunger -= Time.deltaTime * hungerRate;
			// Clamp the hunger.
			currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
			// Reduce health if the hunger is depleted (starving).
			if (currentHunger <= 0)
			{
				playerHealth.ChangeHealth(Time.deltaTime * damageRate);
			}
		}
	}
}
