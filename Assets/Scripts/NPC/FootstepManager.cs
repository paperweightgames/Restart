using System;
using UnityEngine;

namespace NPC
{
    [RequireComponent(typeof(Rigidbody))]
    public class FootstepManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _footstepSource;
        [SerializeField] private float _distance;
        private Vector3 _oldPosition;

        private void FixedUpdate()
        {
            var tPosition = transform.position;
            // Distance moved.
            _distance = Vector3.Distance(tPosition, _oldPosition);

            _footstepSource.volume = _distance > 0 ? 1f : 0;

            // Reset the old position.
            _oldPosition = tPosition;
        }
    }
}