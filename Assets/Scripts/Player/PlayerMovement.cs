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
			if (Mathf.Abs(h) + Mathf.Abs(v) > 0)
			{
				MovePlayer(new Vector2(h, v));
			}
		}

		private void MovePlayer(Vector2 input)
		{
			if (input != Vector2.zero) alignTransform.enabled = true;
			var tf = transform;
			var movementX = tf.right * input.x;
			var movementZ = tf.forward * input.y;
			var movementVector = (movementX + movementZ) * movementSpeed;
			_rb.MovePosition(tf.position + movementVector);
		}
	}
}