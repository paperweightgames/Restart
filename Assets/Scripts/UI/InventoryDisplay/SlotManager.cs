using Items;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InventoryDisplay
{
    public class SlotManager : MonoBehaviour
    {
        [SerializeField] private Text _nameText;
        [SerializeField] private Text _descriptionText;
        [SerializeField] private Button _button;
        [SerializeField] private Text _buttonText;
        [SerializeField] private Image _imageComponent;
        public void SetName(string newName)
        {
            _nameText.text = newName;
        }

        public void SetDescription(string newDescription)
        {
            _descriptionText.text = newDescription;
        }
        
        public void SetButtonText(string newAction)
        {
            _buttonText.text = newAction;
        }

        public void IsButtonEnabled(bool isOn)
        {
            _button.interactable = isOn;
        }

        public void SetBuyItem(Inventory playerInventory, PlayerBalance playerBalance, Item itemToBuy, ShopDisplay shopDisplay)
        {
            _button.onClick.AddListener(delegate { Shop.Buy(playerInventory, playerBalance, itemToBuy, shopDisplay); });
        }

        public void SetEatItem(Food itemToEat, PlayerEating playerEating)
        {
            _button.onClick.AddListener(delegate { playerEating.Eat(itemToEat); });
        }

        public void SetSprite(Sprite newSprite)
        {
            _imageComponent.sprite = newSprite;
        }

        public void ResetButtonAction()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}