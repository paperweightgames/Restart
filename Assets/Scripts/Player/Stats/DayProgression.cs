using UnityEngine;

namespace Player.Stats {
	public class DayProgression : MonoBehaviour
	{
		[SerializeField] private int balanceChange;
		[SerializeField] private float healthChange;
		[SerializeField] private float thirstChange;

		public void ChangeBalance(int amount)
		{
			balanceChange += amount;
		}
		
		private void ResetProgress()
		{
			balanceChange = 0;
			healthChange = 0;
			thirstChange = 0;
		}
	}
}
