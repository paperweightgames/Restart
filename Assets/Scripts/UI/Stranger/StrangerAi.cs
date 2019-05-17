using UnityEngine;
using UnityEngine.AI;

namespace Stranger {
	[RequireComponent(typeof(NavMeshAgent))]
	public class StrangerAi : MonoBehaviour
	{
		[SerializeField] private float _distanceThreshold;
		[SerializeField] private Vector3 _goal;
		[SerializeField] private StrangerSpawner _strangerSpawner;
		private NavMeshAgent _navMeshAgent;

		private void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
		}

		private void Start()
		{
			SetGoal(StrangerSpawner.GetRandomSpawnPoint(_strangerSpawner.GetSpawnPoints()));
		}

		public void SetGoal(Vector3 newGoal)
		{
			_goal = newGoal;
			_navMeshAgent.SetDestination(_goal);
		}

		public void SetStrangerSpawner(StrangerSpawner newStrangerSpawner)
		{
			_strangerSpawner = newStrangerSpawner;
		}

		private void Update()
		{
			var distanceToGoal = Vector3.Distance(transform.position, _goal);
			if (distanceToGoal <= _distanceThreshold)
			{
				// Despawn.
				_strangerSpawner.UnregisterStranger(gameObject);
				Destroy(gameObject);
			}
		}
	}
}
