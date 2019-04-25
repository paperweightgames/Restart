using Player.Stats;
using UnityEngine;

namespace Player {
	public class PlayerBalance : MonoBehaviour
	{
		[SerializeField] private int _balance;
		[SerializeField] private DayProgression _dayProgression;

		public int GetBalance()
		{
			return _balance;
		}
		
		public void ChangeBalance(int amount)
		{
			_dayProgression.ChangeBalance(amount);
			_balance += amount;
		}
	}
}
