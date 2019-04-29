using UnityEngine;

namespace Items {
	[CreateAssetMenu(fileName = "Food Item", menuName = "Item/Food", order = 0)]
	public class Food : Item
	{
		[SerializeField, Header("Food")] private int _hungerRestore;
		[SerializeField] private int _thirstRestore;
	}
}
