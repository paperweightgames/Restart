using Items;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Window {
	public class ShopWindow : MonoBehaviour
	{
		[SerializeField] private GameObject _shopObject;
		[SerializeField] private Text _shopText;
		[SerializeField] private GameObject _slotPrefab;
		[SerializeField] private Transform _rowTransform;

		public void ToggleShop(bool isOn)
		{
			// Enable the object if it is on.
			_shopObject.SetActive(isOn);
		}

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
				// Create new slots.
				var newSlot = Instantiate(_slotPrefab, _rowTransform);
				var slotManager = newSlot.GetComponent<SlotManager>();
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
