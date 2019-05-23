using UnityEngine;

namespace Player
{
    public class StrangerTracker : MonoBehaviour
    {
        [SerializeField] private bool _isStrangerLooking;

        public bool IsStrangerLooking()
        {
            return _isStrangerLooking;
        }

        public void SetIsStrangerLooking(bool isLooking)
        {
            _isStrangerLooking = isLooking;
        }
    }
}