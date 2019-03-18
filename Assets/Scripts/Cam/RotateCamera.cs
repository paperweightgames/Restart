using UnityEngine;

namespace Cam
{
    public class RotateCamera : MonoBehaviour
    {
        [SerializeField] private Vector2 sensitivity;
        private void Update()
        {
            // Get input.
            var h = Input.GetAxis("Mouse X");
            var v = Input.GetAxis("Mouse Y");
            Rotate(new Vector2(v, h));
        }

        private void Rotate(Vector2 input)
        {
            var inputVector = new Vector3(-input.x * sensitivity.x, input.y * sensitivity.y, 0);
            var targetRotation = transform.eulerAngles + inputVector;
            transform.eulerAngles = targetRotation;
        }
    }
}
