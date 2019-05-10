using Cam;
using UnityEngine;

namespace UI.Window {
	public class WindowManager : MonoBehaviour
	{
		[SerializeField] private float _menuTime, _normalTime;
		[SerializeField] private RotateCamera _rotateCamera;
		[SerializeField] private FollowTarget _followTarget;
		[SerializeField] private CursorLock _cursorLock;

		public void ToggleMenu(bool isOn)
		{
			// Change the speed of the game when in a menu.
			Time.timeScale = isOn ? _menuTime : _normalTime;
			// Stop camera movement when in a menu.
			_rotateCamera.enabled = !isOn;
			_followTarget.enabled = !isOn;
			// Enable the cursor when in a menu.
			_cursorLock.enabled = !isOn;
		}
	}
}
