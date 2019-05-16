using UnityEngine;

namespace UI.Window {
	public class WindowBase : MonoBehaviour
	{
		[SerializeField] protected MasterInput _masterInput;
		[SerializeField] protected WindowManager _windowManager;
		[SerializeField] protected GameObject _menuContainer;

		protected virtual void Start()
		{
			_masterInput.Inventory.Close.performed += context => ToggleWindow(false);
		}

		protected virtual void OnEnable()
		{
			_masterInput.Inventory.Close.Enable();
		}

		protected virtual void OnDisable()
		{
			_masterInput.Inventory.Close.Disable();
		}

		public void ToggleWindow(bool isOn)
		{
			_menuContainer.SetActive(isOn);
			_windowManager.ToggleMenu(isOn);
		}
	}
}
