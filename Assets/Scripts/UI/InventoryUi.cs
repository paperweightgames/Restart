using Cam;
using UnityEngine;

namespace UI {
	public class InventoryUi : MonoBehaviour
	{
		[SerializeField] private float normalTimeScale;
		[SerializeField] private float inventoryTimeScale;
		[SerializeField] private GameObject inventoryObject;
		[SerializeField] private RotateCamera rotateCamera;
		[SerializeField] private KeyCode inventoryKey;

		private void Start()
		{
			ToggleInventory(false);
		}

		public void ToggleInventory(bool isOn)
		{
			// Enable the object if it is on.
			inventoryObject.SetActive(isOn);
			// Change the timescale.
			Time.timeScale = isOn ? inventoryTimeScale : normalTimeScale;
			// Disable the camera movement in the inventory.
			rotateCamera.enabled = !isOn;
		}

		private void Update()
		{
			if (Input.GetKeyDown(inventoryKey))
			{
				ToggleInventory(!inventoryObject.activeSelf);
			}
		}
	}
}
