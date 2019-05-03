using UnityEngine;

namespace Items {
	[CreateAssetMenu(fileName = "Inventory", menuName = "Item/Inventory", order = 0)]
	public class Inventory : ScriptableObject
	{
		[SerializeField] private string _name;
		[SerializeField] private Item[] _storedItems;

		public string GetName()
		{
			return _name;
		}
		
		public Item[] GetStoredItems()
		{
			return _storedItems;
		}

		public bool AddItem(Item itemToAdd)
		{
			// Go through all the stored items.
			for (var i = 0; i < _storedItems.Length; i++)
			{
				// Only add the item if the slot is empty.
				if (_storedItems[i] != null) continue;
				
				// Replace the empty slot with the item.
				_storedItems[i] = itemToAdd;
				return true;
			}
			// Return false if there are no empty slots.
			return false;
		}

		public bool RemoveItem(Item itemToRemove)
		{
			// Go through all the store items.
			for (var i = 0; i < _storedItems.Length; i++)
			{
				// Check if the slot contains the item to be removed.
				if (_storedItems[i] == itemToRemove)
				{
					_storedItems[i] = null;
					return true;
				}
			}
			// Return false if the item is not in the inventory.
			return false;
		}

		public void ClearInventory()
		{
			for (var i = 0; i < _storedItems.Length; i++)
			{
				_storedItems[i] = null;
			}
		}
	}
}
