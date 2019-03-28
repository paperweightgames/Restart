using UnityEngine;

namespace Player {
	public class PlayerBalance : MonoBehaviour
	{
		[SerializeField] private int balance;

		public void ChangeMoney(int amount)
		{
			balance += amount;
		}

		public int GetBalance()
		{
			return balance;
		}
	}
}
