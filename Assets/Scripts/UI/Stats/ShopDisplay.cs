using Items;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Stats {
	public class ShopDisplay : MonoBehaviour
	{
		[SerializeField] private Inventory _shopInventory;
		[SerializeField] private GameObject[] _itemSlots;
		[SerializeField] private Text _shopText;
		[SerializeField] private GameObject _slotPrefab;
		[SerializeField] private Transform _rowTransform;

		public void GenerateShop()
		{
			
		}
	}
}
