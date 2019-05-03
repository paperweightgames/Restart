using Cam;
using UnityEngine;

namespace UI {
	public class InventoryUi : MonoBehaviour
	{
		[SerializeField] private MasterInput _masterInput;
		[SerializeField] private float _normalTimeScale;
		[SerializeField] private float _inventoryTimeScale;
		[SerializeField] private GameObject _inventoryObject;
		[SerializeField] private RotateCamera _rotateCamera;
		[SerializeField] private CursorLock _cursorLock;

		private void OnEnable()
		{
			_masterInput.Inventory.Toggle.Enable();
			_masterInput.Inventory.Toggle.performed += context => ToggleInventory(!_inventoryObject.activeSelf);
		}

		private void Start()
		{
			ToggleInventory(false);
		}

		public void ToggleInventory(bool isOn)
		{
			// Enable the object if it is on.
			_inventoryObject.SetActive(isOn);
			// Change the timescale.
			Time.timeScale = isOn ? _inventoryTimeScale : _normalTimeScale;
			// Disable the camera movement in the inventory.
			_rotateCamera.enabled = !isOn;
			// Toggle the lock state of the cursor.
			_cursorLock.enabled = isOn;
		}
	}
}
