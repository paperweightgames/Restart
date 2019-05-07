using UnityEngine;
using UnityEngine.Experimental.Input;

namespace Cam
{
	public class RotateCamera : MonoBehaviour
	{
		[SerializeField] private MasterInput _inputSystem;
		[SerializeField] private Vector2 _rotateSensitivity = new Vector2(2, 2);
		[SerializeField, Tooltip("X is min rotation, Y is max rotation.")] private Vector2 _cameraBounds;
		private Vector3 _angle;

		private void Awake()
		{
			_inputSystem.Player.Look.Enable();
			_inputSystem.Player.Look.performed += context => Rotate(context.ReadValue<Vector2>());
		}

		private void OnDestroy()
		{
			_inputSystem.Player.Look.Disable();
		}

		private void Start()
		{
			// Set the current to the rotation of the camera at the start of the game.
			_angle = transform.eulerAngles;
		}

		private void Rotate(Vector2 input)
		{
			input *= Time.deltaTime;
			// Apply the sensitivity to the input.
			var inputVector = new Vector3(input.y * _rotateSensitivity.y, input.x * _rotateSensitivity.x, 0);
			// Add the input to the current angle.
			_angle += inputVector;
			
			// Keep the angle clamped between the bounds.
			_angle.x = Mathf.Clamp(_angle.x, _cameraBounds.x, _cameraBounds.y);
			
			// Apply the target angle to the GameObject.
			transform.eulerAngles = _angle;
		}
	}
}
