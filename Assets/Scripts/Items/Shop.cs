using Player;
using UnityEngine;

namespace Items {
	public class Shop : MonoBehaviour
	{
		public static void Buy(Inventory playerInventory, PlayerBalance playerBalance, Item itemToBuy)
		{
			// Check if the player can afford the item.
			var itemValue = itemToBuy.GetValue();
			var canAfford = playerBalance.GetBalance() >= itemValue;

			// Return if the item is too expensive.
			if (!canAfford) return;
			
			// Add the item to the inventory.
			playerInventory.AddItem(itemToBuy);
			// Remove the price of the item from the 
			playerBalance.ChangeBalance(-itemValue);
		}
	}
}
