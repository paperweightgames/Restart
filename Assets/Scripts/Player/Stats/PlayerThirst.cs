using UnityEngine;

namespace Player.Stats {
	public class PlayerThirst : MonoBehaviour
	{
		[SerializeField] private float maxThirst;
		[SerializeField] private float currentThirst;
		[SerializeField] private float thirstRate;
		[SerializeField] private float damageRate;
		[SerializeField, Header("References")] private PlayerHealth playerHealth;
		[SerializeField] private TimeCycle timeCycle;

		public float GetMaxThirst()
		{
			return maxThirst;
		}

		public float GetCurrentThirst()
		{
			return currentThirst;
		}

		private void Update()
		{
			// Scale the amount of hunger to the length of the day.
			var dayRate = 1 / timeCycle.GetDayLength();
			// Reduce the hunger.
			currentThirst -= Time.deltaTime * thirstRate * dayRate;
			// Clamp the hunger.
			currentThirst = Mathf.Clamp(currentThirst, 0, maxThirst);
			// Reduce health if the hunger is depleted (starving).
			if (currentThirst <= 0)
			{
				playerHealth.ChangeHealth(-Time.deltaTime * damageRate * dayRate);
			}
		}
	}
}
