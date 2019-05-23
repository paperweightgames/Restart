using UnityEngine;

namespace Settings
{
    [RequireComponent(typeof(Camera))]
    public class Fov : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            _camera.fieldOfView = PlayerPrefs.GetInt("Field Of View", 60);
        }
    }
}