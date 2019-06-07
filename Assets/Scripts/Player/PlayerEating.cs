using Items;
using Player.Stats;
using UI.InventoryDisplay;
using UnityEngine;

namespace Player
{
    public class PlayerEating : MonoBehaviour
    {
        [SerializeField] private PlayerHunger _playerHunger;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private InventoryDisplay _inventoryDisplay;

        public void Eat(Food foodToEat)
        {
            _playerHunger.ChangeCurrentHunger(foodToEat.GetHungerRestore());
            _inventory.RemoveItem(foodToEat);
            _inventoryDisplay.Regenerate(); 
        }
    }
}