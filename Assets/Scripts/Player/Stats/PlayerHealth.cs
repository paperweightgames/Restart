using UnityEngine;

namespace Player.Stats {
	public class PlayerHealth : MonoBehaviour
	{
		[SerializeField] private float maxHealth;
		[SerializeField] private float currentHealth;

		public void ChangeHealth(float amount)
		{
			currentHealth += amount;
		}
		
		public float GetMaxHealth()
		{
			return maxHealth;
		}

		public float GetCurrentHealth()
		{
			return currentHealth;
		}
	}
}
