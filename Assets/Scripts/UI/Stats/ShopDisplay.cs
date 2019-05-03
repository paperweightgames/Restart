using Items;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Stats {
	public class ShopDisplay : MonoBehaviour
	{
		[SerializeField] private GameObject _shopObject;
		[SerializeField] private Inventory _shopInventory;
		[SerializeField] private GameObject[] _itemSlots;
		[SerializeField] private Text _shopText;
		[SerializeField] private GameObject _slotPrefab;
		[SerializeField] private Transform _rowTransform;
		[SerializeField] private InventoryUi _inventoryUi;

		private void Start()
		{
			GenerateShop();
		}

		public void ToggleShop(bool isOn)
		{
			// Enable the object if it is on.
			_shopObject.SetActive(isOn);
		}

		public void GenerateShop()
		{
			var shopItems = _shopInventory.GetStoredItems();
			// Generate a slot for each item.
			for (int i = 0; i < shopItems.Length; i++)
			{
				// Create new slots.
				var newSlot = Instantiate(_slotPrefab, _rowTransform);
				var slotManager = newSlot.GetComponent<SlotManager>();
				slotManager.ChangeItem(shopItems[i]);
			}
		}
	}
}
