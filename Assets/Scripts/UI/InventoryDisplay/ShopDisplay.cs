using Items;

namespace UI.InventoryDisplay
{
    public class ShopDisplay : InventoryDisplay
    {
        public override void ConfigureSlot(Item item, SlotManager slotManager)
        {
            base.ConfigureSlot(item, slotManager);
            // Replace the default action with buy.
            slotManager.SetButtonText("Buy");
        }

        public void SetTargetInventory(Inventory newInventory)
        {
            _targetInventory = newInventory;
        }
    }
}