using UnityEngine;

namespace Items {
	public class InventoryReset : MonoBehaviour
	{
		[SerializeField] private Inventory _playerInventory;

		private void Start()
		{
			_playerInventory.ClearInventory();
		}
	}
}
