using Items;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Window {
	public class ShopWindow : WindowBase
	{
		[SerializeField] private Text _shopText;
		[SerializeField] private GameObject _slotPrefab;
		[SerializeField] private Transform _rowTransform;
		[SerializeField] private PlayerBalance _playerBalance;

		public void GenerateShop(Inventory shopInventory)
		{
			// Clear the current shop.
			ClearShop();
			
			// Set the title of the shop.
			_shopText.text = shopInventory.GetName();
			var shopItems = shopInventory.GetStoredItems();
			// Generate a slot for each item.
			for (int i = 0; i < shopItems.Length; i++)
			{
				// Check if the player can afford the item.
				var canAfford = shopItems[i].GetValue() <= _playerBalance.GetBalance();
				// Create new slots.
				var newSlot = Instantiate(_slotPrefab, _rowTransform);
				var slotManager = newSlot.GetComponent<SlotManager>();
				slotManager.ToggleBuyButton(canAfford);
				slotManager.ChangeItem(shopItems[i]);
			}
		}

		private void ClearShop()
		{
			foreach (Transform child in _rowTransform.transform)
			{
				Destroy(child.gameObject);
			}
		}
	}
}
