using UnityEngine;
using UnityEngine.AI;

namespace Stranger {
	[RequireComponent(typeof(NavMeshAgent))]
	public class StrangerAi : MonoBehaviour
	{
		[SerializeField] private float _distanceThreshold;
		[SerializeField] private Vector3 _goal;
		[SerializeField] private Transform[] _spawnPoints;
		private NavMeshAgent _navMeshAgent;

		private void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
		}

		public void SetGoal(Vector3 newGoal)
		{
			_goal = newGoal;
			_navMeshAgent.SetDestination(_goal);
		}

		public void SetSpawnPoints(Transform[] newPoints)
		{
			_spawnPoints = newPoints;
		}

		private void Update()
		{
			var distanceToGoal = Vector3.Distance(transform.position, _goal);
			if (distanceToGoal <= _distanceThreshold)
			{
				SetGoal(StrangerSpawner.GetRandomSpawnPoint(_spawnPoints));
			}
		}
	}
}
