using UnityEngine;

namespace Player {
	public class PlayerBalance : MonoBehaviour
	{
		[SerializeField] private int balance;


		private void Start()
		{
			ChangeMoney(195);
		}

		public void ChangeMoney(int amount)
		{
			balance += amount;
		}

		public int GetBalance()
		{
			return balance;
		}

		public static void Beg()
		{
			FindObjectOfType<PlayerMovement>().SendMessage("ChangeMoney", 5);
		}
	}
}
