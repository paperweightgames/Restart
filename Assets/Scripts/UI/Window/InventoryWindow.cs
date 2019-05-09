namespace UI.Window {
	public class InventoryWindow : WindowBase
	{
		private void Awake()
		{
			_masterInput.Inventory.Toggle.Enable();
			_masterInput.Inventory.Toggle.performed += context => ToggleWindow(!_menuContainer.activeSelf);
		}

		private void OnDestroy()
		{
			_masterInput.Inventory.Toggle.Disable();
		}
	}
}
