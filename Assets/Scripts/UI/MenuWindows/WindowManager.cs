using Cam;
using UnityEngine;

namespace UI.MenuWindows {
	public class WindowManager : MonoBehaviour
	{
		[SerializeField] private float _timeMultiplier;
		[SerializeField] private CursorLock _cursorLock;
		[SerializeField] private RotateCamera _rotateCamera;

		public void ToggleWindows(bool isOn)
		{
			// Slow time down when in a menu, and reset it when not.
			Time.timeScale *= isOn ? _timeMultiplier : 1 / _timeMultiplier;
			// Enable the pointer.
			_cursorLock.enabled = isOn;
			// Disable camera movement when a window is active.
			_rotateCamera.enabled = !isOn;
		}
	}
}
