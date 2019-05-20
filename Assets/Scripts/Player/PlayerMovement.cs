using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private MasterInput _masterInput;
		[SerializeField] private AlignTransform.AlignTransform _alignTransform;
		[SerializeField] private float _movementSpeed;
		[SerializeField] private Vector2 _moveForce;
		private Rigidbody _rb;

		private void Awake()
		{
			_masterInput.Player.Move.Enable();
			_masterInput.Player.Move.performed += context => SetMoveForce(context.ReadValue<Vector2>());
			_masterInput.Player.Move.cancelled += context => SetMoveForce(context.ReadValue<Vector2>());
			// Get the reference to the rigid body component that's attached to this GameObject.
			_rb = GetComponent<Rigidbody>();
		}

		private void OnDestroy()
		{
			_masterInput.Player.Move.Disable();
		}

		private void FixedUpdate()
		{
			// Stop aligning the player with the camera.
			_alignTransform.enabled = false;

			MovePlayer(_moveForce);
		}

		private void SetMoveForce(Vector2 newForce)
		{
			_moveForce = newForce;
		}
		
		private void MovePlayer(Vector2 input)
		{
			input *= Time.deltaTime;
			// If the player is moving, align them with the camera.
			_alignTransform.enabled = true;
			
			// Work out the new movement position.
			var tf = transform;
			var movementX = tf.right * input.x;
			var movementZ = tf.forward * input.y;
			var movementVector = (movementX + movementZ) * _movementSpeed;
			// Add the new position to the current position.
			_rb.MovePosition(tf.position + movementVector);
			
			// Update Animations.
			_animator.SetTrigger(input == Vector2.zero ? "Idle" : "Walk");
		}
	}
}