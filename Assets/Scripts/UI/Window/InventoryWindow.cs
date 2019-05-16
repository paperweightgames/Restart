namespace UI.Window
{
    public class InventoryWindow : WindowBase
    {
        protected override void Start()
        {
            base.Start();
            _masterInput.Inventory.Toggle.performed += context => ToggleWindow(!_menuContainer.activeSelf);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _masterInput.Inventory.Toggle.Enable();
        }
        
        protected override void OnDisable()
        {
            base.OnDisable();
            _masterInput.Inventory.Toggle.Disable();
        }
    }
}