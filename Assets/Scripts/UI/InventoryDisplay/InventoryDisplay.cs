using Items;
using Player;
using UnityEngine;

namespace UI.InventoryDisplay
{
    public class InventoryDisplay : MonoBehaviour
    {
        [SerializeField] private PlayerEating _playerEating;
        [SerializeField] private Transform _rowTransform;
        [SerializeField] private GameObject _slotPrefab;
        [SerializeField] protected Inventory _targetInventory;

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
            slotManager.SetSprite(item.GetSprite());
            slotManager.IsButtonEnabled(true);

            if (item.GetType() == typeof(Food))
            {
                slotManager.SetEatItem((Food)item, _playerEating);
            }
        }
        
        public void GenerateSlots(Inventory targetInventory)
        {
            // Clear any previous slots.
            ClearRow();
            
            // Generate a slot for each item in the inventory.
            foreach (var item in targetInventory.GetStoredItems())
            {
                // Skip the item if it is empty.
                if (item == null) continue;
                
                var slot = Instantiate(_slotPrefab, _rowTransform);
                var slotManager = slot.GetComponent<SlotManager>();
                ConfigureSlot(item, slotManager);
            }
        }

        private void OnEnable()
        {
            Regenerate();
        }
        
        public void Regenerate()
        {
            GenerateSlots(_targetInventory);
        }
    }
}