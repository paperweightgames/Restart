using UnityEngine;

namespace AlignTransform
{
	public class AlignTransform : MonoBehaviour
	{
		[SerializeField] private Transform _targetTransform;
		[SerializeField] private bool _alignX, _alignY, _alignZ;
		[SerializeField, Range(0, 1)] private float _speed;

		private void Update()
		{
			// Gets the references of the euler angles for the target and the object itself.
			var targetRotation = _targetTransform.eulerAngles;
			var eulerAngles = transform.eulerAngles;
			
			// The script allows you to toggle aligning each axis.
			var targetX = _alignX ? targetRotation.x : eulerAngles.x;
			var targetY = _alignY ? targetRotation.y : eulerAngles.y;
			var targetZ = _alignZ ? targetRotation.z : eulerAngles.z;
			// Works out the target angle.
			var targetAngle = new Vector3(targetX, targetY, targetZ);
			
			// Smoothly transitions to the target angle.
			transform.eulerAngles = Vector3.Lerp(eulerAngles, targetAngle, _speed);
		}
	}
}