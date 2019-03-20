using UnityEngine;

namespace Cam
{
    public class RotateCamera : MonoBehaviour
    {
        [SerializeField] private Vector2 rotateSensitivity = new Vector2(2, 2);
        private void Update()
        {
            // Get input for rotation.
            var h = Input.GetAxis("Mouse X");
            var v = Input.GetAxis("Mouse Y");
            Rotate(new Vector2(v, h));
        }

        private void Rotate(Vector2 input)
        {
            var inputVector = new Vector3(-input.x * rotateSensitivity.x, input.y * rotateSensitivity.y, 0);
            var tf = transform;
            var targetRotation = tf.eulerAngles + inputVector;
            tf.eulerAngles = targetRotation;
        }
    }
}
