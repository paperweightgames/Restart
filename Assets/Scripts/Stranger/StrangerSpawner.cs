using UnityEngine;

namespace Stranger {
	public class StrangerSpawner : MonoBehaviour
	{
		[SerializeField] private GameObject _strangerPrefab;
		[SerializeField] private Transform[] _spawnPoints;
		[SerializeField] private float _spawnRate, _spawnSpread;
		private float _timeToSpawn;
		private float _timeSinceSpawn;

		private void Start()
		{
			SetSpawnRate();
		}

		private void SetSpawnRate()
		{
			_timeToSpawn = _spawnRate + Random.Range(-_spawnSpread, _spawnSpread);
		}

		public static Vector3 GetRandomSpawnPoint(Transform[] spawnPoints)
		{
			var randomSpawnPointIndex = Random.Range(0, spawnPoints.Length - 1);
			var randomSpawnPoint = spawnPoints[randomSpawnPointIndex];
			return randomSpawnPoint.position;
		}
		
		private void Update()
		{
			_timeSinceSpawn += Time.deltaTime;
			_timeSinceSpawn = Mathf.Clamp(_timeSinceSpawn, 0, _timeToSpawn);
			
			// Spawn a new stranger.
			if (_timeSinceSpawn >= _timeToSpawn)
			{
				_timeSinceSpawn = 0;
				SetSpawnRate();

				var spawnPosition = GetRandomSpawnPoint(_spawnPoints);
				var newStranger = Instantiate(_strangerPrefab, spawnPosition, Quaternion.identity,
					transform);
				var strangerAi = newStranger.GetComponent<StrangerAi>();
				strangerAi.SetGoal(GetRandomSpawnPoint(_spawnPoints));
			}
		}
	}
}
