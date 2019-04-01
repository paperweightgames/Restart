using UnityEngine;

namespace Cam
{
    public class RotateCamera : MonoBehaviour
    {
        [SerializeField] private Vector2 rotateSensitivity = new Vector2(2, 2);
        [SerializeField, Tooltip("X is min rotation, Y is max rotation.")] private Vector2 cameraBounds;
        private Vector3 angle;

        private void Start()
        {
            angle = transform.eulerAngles;
        }

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
            angle += inputVector;
            // Keep the angle clamped between the bounds.
            angle.x = Mathf.Clamp(angle.x, cameraBounds.x, cameraBounds.y);
            transform.eulerAngles = angle;
            print(angle);
        }
    }
}
