using Items;
using UnityEngine;

namespace UI.InventoryDisplay
{
    public class InventoryDisplay : MonoBehaviour
    {
        [SerializeField] private Transform _rowTransform;
        [SerializeField] private GameObject _slotPrefab;

        public void ClearRow()
        {
            foreach (Transform child in _rowTransform)
            {
                Destroy(child.gameObject);
            }
        }

        public virtual void ConfigureSlot(Item item, SlotManager slotManager)
        {
            slotManager.SetName(item.GetName());
            slotManager.SetDescription(item.GetDescription());
            slotManager.SetButtonText(item.GetAction());
        }
        
        public void GenerateRows(Inventory targetInventory)
        {
            // Clear any previous slots.
            ClearRow();
            
            // Generate a slot for each item in the inventory.
            foreach (var item in targetInventory.GetStoredItems())
            {
                var slot = Instantiate(_slotPrefab, _rowTransform);
                var slotManager = slot.GetComponent<SlotManager>();
                ConfigureSlot(item, slotManager);
            }
        }
    }
}