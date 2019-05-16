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
        
        
    }
}