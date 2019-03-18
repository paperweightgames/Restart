using UnityEngine;

namespace AlignTransform
{
	public class AlignTransform : MonoBehaviour
	{
		[SerializeField] private Transform targetTransform;
		[SerializeField] private bool alignX, alignY, alignZ;
		[SerializeField, Range(0, 1)] private float speed;

		private void Update()
		{
			var targetRotation = targetTransform.eulerAngles;
			var eulerAngles = transform.eulerAngles;
			
			var targetX = alignX ? targetRotation.x : eulerAngles.x;
			var targetY = alignY ? targetRotation.y : eulerAngles.y;
			var targetZ = alignZ ? targetRotation.z : eulerAngles.z;
			var targetAngle = new Vector3(targetX, targetY, targetZ);
			
			transform.eulerAngles = Vector3.Lerp(eulerAngles, targetAngle, speed);
		}
	}
}