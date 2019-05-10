using Items;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class SlotManager : MonoBehaviour
	{
		[SerializeField] private Item _item;
		[SerializeField] private Image _imageComponent;
		[SerializeField] private Text _name, _price, _description;
		[SerializeField] private Button _buyButton;

		public void ChangeItem(Item newItem)
		{
			_item = newItem;
			UpdateDisplay();
		}

		public void ToggleBuyButton(bool isOn)
		{
			_buyButton.interactable = isOn;
		}
		
		private void UpdateDisplay()
		{
			_imageComponent.sprite = _item.GetSprite();
			_name.text = _item.GetName();
			_price.text = $"{_item.GetValue() / 100f:c2}";
			_description.text = _item.GetDescription();
		}
	}
}
