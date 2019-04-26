using UnityEngine;
using UnityEngine.Experimental.Input;

namespace Cam
{
	public class RotateCamera : MonoBehaviour
	{
		[SerializeField] private MasterInput _inputSystem;
		[SerializeField] private Vector2 rotateSensitivity = new Vector2(2, 2);
		[SerializeField, Tooltip("X is min rotation, Y is max rotation.")] private Vector2 cameraBounds;
		private Vector3 _angle;

		private void Start()
		{
			// Set the current to the rotation of the camera at the start of the game.
			_angle = transform.eulerAngles;

			_inputSystem.Player.Look.performed += context => Rotate(context.ReadValue<Vector2>());
		}

		private void Rotate(Vector2 input)
		{
			print(input);
			// Apply the sensitivity to the input.
			var inputVector = new Vector3(-input.x * rotateSensitivity.x, input.y * rotateSensitivity.y, 0);
			// Add the input to the current angle.
			_angle += inputVector;
			
			// Keep the angle clamped between the bounds.
			_angle.x = Mathf.Clamp(_angle.x, cameraBounds.x, cameraBounds.y);
			
			// Apply the target angle to the GameObject.
			transform.eulerAngles = _angle;
		}
	}
}
