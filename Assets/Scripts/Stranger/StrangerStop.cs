using Player;
using UnityEngine;
using UnityEngine.AI;

namespace Stranger {
	[RequireComponent(typeof(NavMeshAgent))]
	public class StrangerStop : MonoBehaviour
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private string _playerTag;
		private NavMeshAgent _navMeshAgent;
		// Animation index.
		private static readonly int Walk = Animator.StringToHash("Walk");
		private static readonly int Idle = Animator.StringToHash("Idle");

		private void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
		}

		private void OnTriggerStay(Collider other)
		{
			// Only check the player.
			if (!other.CompareTag(_playerTag) || other.isTrigger) return;
			
			// Only stop if the player is begging to this stranger.
			if (other.GetComponent<PlayerInteracting>().IsBegging() != gameObject)
			{
				SetMoving(true);
				return;
			}
			
			// Stop if the stranger is the one being begged.
			SetMoving(false);
			transform.LookAt(other.transform);
		}

		private void OnTriggerExit(Collider other)
		{
			if (!other.CompareTag(_playerTag) || other.isTrigger) return;
			
			SetMoving(true);
		}

		private void SetMoving(bool isMoving)
		{
			_navMeshAgent.isStopped = !isMoving;
			_animator.SetTrigger(isMoving ? Walk : Idle);
		}
	}
}
