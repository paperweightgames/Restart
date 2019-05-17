using UnityEngine;

namespace Cam
{
	[RequireComponent(typeof(Camera))]
	public class FollowTarget : MonoBehaviour
	{
		[SerializeField] private Transform _targetTransform;
		[SerializeField] private Vector3 _offset;
		[SerializeField, Range(0, 1)] private float _speed;
		[SerializeField] private float _zoomSpeed;
		[SerializeField] private Vector2 _zoomBounds;
		private float _zoomPercentage;
		private float _zoomDistance;
		private float _maxDistance;

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
			var offsetX = tf.right * _offset.x;
			var offsetY = tf.up * _offset.y;
			var offsetZ = tf.forward * _offset.z;
			var zoomZ = tf.forward * (_offset.z + _zoomDistance);
			// Works out the target position by combining the offset and the position of the target.
			var targetPosition = _targetTransform.position + offsetX + offsetY + zoomZ;
			// Smoothly transitions the position to the target.
			tf.position = Vector3.Lerp(tf.position, targetPosition, _speed);

			var offsetPosition = _targetTransform.position + offsetX + offsetY + offsetZ;
			var ray = new Ray(offsetPosition, transform.forward * _zoomBounds.x);
			RaycastHit hit;
			Physics.Raycast(ray, out hit);

			if (!ReferenceEquals(hit.collider, null))
			{
				_maxDistance = hit.distance;
			}
		}
		
		private void Zoom (float input)
		{
			// Changes the zoom offset based on the input.
			var maxZoom = Mathf.Clamp(_zoomBounds.x, -_maxDistance + 0.1f, _zoomBounds.y);

			_zoomPercentage = Mathf.Clamp01(_zoomPercentage + input * _zoomSpeed);
			_zoomDistance = Mathf.Lerp(maxZoom, _zoomBounds.y, _zoomPercentage);
		}
	}
}
