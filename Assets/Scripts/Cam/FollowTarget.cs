using UnityEngine;

namespace Cam
{
    [RequireComponent(typeof(Camera))]
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Vector3 offset;
        [SerializeField, Range(0, 1)] private float speed;

        private void Update()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            var offsetX = transform.right * offset.x;
            var offsetY = transform.up * offset.y;
            var offsetZ = transform.forward * offset.z;
            var targetPosition = targetTransform.position + offsetX + offsetY + offsetZ;
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed);
        }
    }
}
