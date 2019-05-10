using UnityEngine;

namespace Player.Stats {
	public class PlayerThirst : MonoBehaviour
	{
		[SerializeField] private float _maxThirst = 150;
		[SerializeField] private float _currentThirst = 150;
		[SerializeField] private float _thirstRate = 75;
		[SerializeField] private float _damageRate = 100;
		[SerializeField, Header("References")] private PlayerHealth _playerHealth;
		[SerializeField] private TimeCycle _timeCycle;

		public float GetMaxThirst()
		{
			return _maxThirst;
		}

		public float GetCurrentThirst()
		{
			return _currentThirst;
		}

		private void Update()
		{
			// Scale the amount of hunger to the length of the day.
			var dayRate = 1 / _timeCycle.GetDayLength();
			// Reduce the hunger.
			_currentThirst -= Time.deltaTime * _thirstRate * dayRate;
			// Clamp the hunger.
			_currentThirst = Mathf.Clamp(_currentThirst, 0, _maxThirst);
			// Reduce health if the hunger is depleted (starving).
			if (_currentThirst <= 0)
			{
				_playerHealth.ChangeHealth(-Time.deltaTime * _damageRate * dayRate);
			}
		}
	}
}
