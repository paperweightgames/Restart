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
			_rb = GetComponent<Rigidbody>();
		}

		private void FixedUpdate()
		{
			// Get input.
			var h = Input.GetAxis("Horizontal");
			var v = Input.GetAxis("Vertical");
			alignTransform.enabled = false;
			MovePlayer(new Vector2(h, v));
		}

		private void MovePlayer(Vector2 input)
		{
			if (input != Vector2.zero) alignTransform.enabled = true;
			var transform1 = transform;
			var movementX = transform1.right * input.x;
			var movementZ = transform1.forward * input.y;
			var movementVector = (movementX + movementZ) * movementSpeed;
			_rb.MovePosition(transform1.position + movementVector);
		}
	}
}