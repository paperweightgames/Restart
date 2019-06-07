using UnityEngine;

namespace Player.Stats {
	public class PlayerHunger : MonoBehaviour
	{
		[SerializeField] private float maxHunger;
		[SerializeField] private float currentHunger;
		[SerializeField] private float hungerRate;
		[SerializeField] private float damageRate;
		[SerializeField, Header("References")] private PlayerHealth playerHealth;
		[SerializeField] private TimeCycle timeCycle;

		public float GetMaxHunger()
		{
			return maxHunger;
		}

		public float GetCurrentHunger()
		{
			return currentHunger;
		}

		public void ChangeCurrentHunger(float amountToChange)
		{
			currentHunger += amountToChange;
			currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
		}
		private void Update()
		{
			// Scale the amount of hunger to the length of the day.
			var dayRate = 1 / timeCycle.GetDayLength();
			// Reduce the hunger.
			ChangeCurrentHunger(-Time.deltaTime * hungerRate * dayRate);
			
			// Reduce health if the hunger is depleted (starving).
			if (currentHunger <= maxHunger * .1f)
			{
				playerHealth.ChangeHealth(-Time.deltaTime * damageRate * dayRate);
			}
		}
	}
}
