using Items;
using Player.Stats;
using UnityEngine;

namespace Player
{
    public class PlayerEating : MonoBehaviour
    {
        [SerializeField] private PlayerHunger _playerHunger;

        public void Eat(Food foodToEat)
        {
            _playerHunger.ChangeCurrentHunger(foodToEat.GetHungerRestore());
        }
    }
}