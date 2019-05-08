using UnityEngine;

namespace UI.Window {
	public class WindowBase : MonoBehaviour
	{
		[SerializeField] protected MasterInput _masterInput;
		[SerializeField] protected WindowManager _windowManager;
		[SerializeField] protected GameObject _menuContainer;

		private void Awake()
		{
			EnableClosing();
		}

		protected void EnableClosing()
		{
			_masterInput.Inventory.Close.Enable();
			_masterInput.Inventory.Close.performed += context => ToggleWindow(false);
		}
		
		public void ToggleWindow(bool isOn)
		{
			_menuContainer.SetActive(isOn);
			_windowManager.ToggleMenu(isOn);
		}
	}
}
