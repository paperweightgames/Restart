using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private AlignTransform.AlignTransform alignTransform;
		[SerializeField] private float movementSpeed;
		private Rigidbody _rb;

		private void Awake()
		{
			// Get the reference to the rigid body component that's attached to this GameObject.
			_rb = GetComponent<Rigidbody>();
		}

		private void FixedUpdate()
		{
			// Get input.
			var h = Input.GetAxis("Horizontal");
			var v = Input.GetAxis("Vertical");
			
			// Stop aligning the player with the camera.
			alignTransform.enabled = false;
			
			// Move the player if any input is detected.
			if (Mathf.Abs(h) + Mathf.Abs(v) > 0)
			{
				MovePlayer(new Vector2(h, v));
			}
		}

		private void MovePlayer(Vector2 input)
		{
			// If the player is moving, align them with the camera.
			alignTransform.enabled = true;
			
			// Work out the new movement position.
			var tf = transform;
			var movementX = tf.right * input.x;
			var movementZ = tf.forward * input.y;
			var movementVector = (movementX + movementZ) * movementSpeed;
			// Add the new position to the current position.
			_rb.MovePosition(tf.position + movementVector);
		}
	}
}