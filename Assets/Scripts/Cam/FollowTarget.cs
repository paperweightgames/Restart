using UnityEngine;

namespace Cam
{
	[RequireComponent(typeof(Camera))]
	public class FollowTarget : MonoBehaviour
	{
		[SerializeField] private Transform targetTransform;
		[SerializeField] private Vector3 offset;
		[SerializeField, Range(0, 1)] private float speed;
		[SerializeField] private float zoomSpeed;
		[SerializeField] private Vector2 zoomBounds;
		private float _zoomOffset;

		private void FixedUpdate()
		{
			UpdatePosition();
			
			// Zooming.
			// Gets the input from the scroll wheel of the mouse.
			var mouseScroll = Input.GetAxis("Mouse ScrollWheel");
			Zoom(mouseScroll);
		}

		private void UpdatePosition()
		{
			// Works out the offset for the camera.
			var tf = transform;
			var offsetX = tf.right * offset.x;
			var offsetY = tf.up * offset.y;
			var offsetZ = tf.forward * (offset.z + _zoomOffset);
			// Works out the target position by combining the offset and the position of the target.
			var targetPosition = targetTransform.position + offsetX + offsetY + offsetZ;
			// Smoothly transitions the position to the target.
			tf.position = Vector3.Lerp(tf.position, targetPosition, speed);
		}
		
		private void Zoom (float input)
		{
			// Changes the zoom offset based on the input.
			_zoomOffset = Mathf.Clamp(_zoomOffset + input * zoomSpeed, zoomBounds.x, zoomBounds.y);
		}
	}
}
