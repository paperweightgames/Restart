using Items;
using Player;
using UnityEngine;

namespace UI.InventoryDisplay
{
    public class ShopDisplay : InventoryDisplay
    {
        [SerializeField] private PlayerBalance _playerBalance;
        [SerializeField] private Inventory _playerInventory;
        
        public override void ConfigureSlot(Item item, SlotManager slotManager)
        {
            base.ConfigureSlot(item, slotManager);
            // Replace the default action with buy.
            slotManager.SetButtonText("Buy");
            slotManager.SetName($"{item.GetName()} - {item.GetValue()/100f:c2}");

            if (_playerBalance.GetBalance() > item.GetValue())
            {
                slotManager.IsButtonEnabled(true);
            }
            slotManager.SetBuyItem(_playerInventory, _playerBalance, item);
        }

        public void SetTargetInventory(Inventory newInventory)
        {
            _targetInventory = newInventory;
        }
    }
}