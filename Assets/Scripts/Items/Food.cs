using UnityEngine;

namespace Items {
	[CreateAssetMenu(fileName = "Food Item", menuName = "Item/Food", order = 0)]
	public class Food : Item
	{
		[Header("Food")]
		[SerializeField] private float _hungerRestore;
		[SerializeField] private int _thirstRestore;

		public float GetHungerRestore()
		{
			return _hungerRestore;
		}
	}
}
