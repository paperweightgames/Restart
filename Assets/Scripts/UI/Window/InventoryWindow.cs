namespace UI.Window {
	public class InventoryWindow : WindowBase
	{
		private void Awake()
		{
			EnableInputs();
		}

		protected override void EnableInputs()
		{
			base.EnableInputs();
			_masterInput.Inventory.Toggle.Enable();
			_masterInput.Inventory.Toggle.performed += context => ToggleWindow(!_menuContainer.activeSelf);
		}

		protected override void DisableInputs()
		{
			base.DisableInputs();
			_masterInput.Inventory.Toggle.Disable();
		}

		private void OnDestroy()
		{
			DisableInputs();
		}
	}
}
