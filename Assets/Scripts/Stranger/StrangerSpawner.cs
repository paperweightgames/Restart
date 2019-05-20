using System.Collections.Generic;
using Conversation;
using Interaction;
using UI;
using UnityEngine;

namespace Stranger {
	public class StrangerSpawner : MonoBehaviour
	{
		[SerializeField] private InteractionObject[] _interactionObjects;
		[SerializeField, Space] private Transform[] _spawnPoints;
		[SerializeField] private float _spawnRate, _spawnSpread;
		[SerializeField] private Vector3 _spread;
		[SerializeField] private int _maxStrangers;
		[SerializeField] private List<GameObject> _strangers;
		[SerializeField] private GameObject _strangerPrefab;
		private float _timeToSpawn;
		private float _timeSinceSpawn;

		private void Start()
		{
			SetSpawnRate();
			_strangers = new List<GameObject>();
		}

		private void SetSpawnRate()
		{
			_timeToSpawn = _spawnRate + Random.Range(-_spawnSpread, _spawnSpread);
		}

		public static Vector3 GetRandomSpawnPoint(Transform[] spawnPoints)
		{
			var randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
			var randomSpawnPoint = spawnPoints[randomSpawnPointIndex];
			return randomSpawnPoint.position;
		}
		
		private void Update()
		{
			_timeSinceSpawn += Time.deltaTime;
			_timeSinceSpawn = Mathf.Clamp(_timeSinceSpawn, 0, _timeToSpawn);
			
			// Spawn a new stranger.
			if (_timeSinceSpawn >= _timeToSpawn && _strangers.Count < _maxStrangers)
			{
				_timeSinceSpawn = 0;
				SetSpawnRate();

				var spawnPosition = GetRandomSpawnPoint(_spawnPoints);
				// Add spread to the spawn position.
				var xSpread = Random.Range(-_spread.x, _spread.x);
				var ySpread = Random.Range(-_spread.y, _spread.y);
				var zSpread = Random.Range(-_spread.z, _spread.z);
				spawnPosition += new Vector3(xSpread, ySpread, zSpread);
				
				
				var newStranger = Instantiate(_strangerPrefab, spawnPosition, Quaternion.identity,
					transform);
				var strangerAi = newStranger.GetComponent<StrangerAi>();
				strangerAi.SetStrangerSpawner(this);
				_strangers.Add(newStranger);
				
				// Assign the conversation.
				var randomInteractionIndex = Random.Range(0, _interactionObjects.Length);
				strangerAi.SetInteraction(_interactionObjects[randomInteractionIndex]);
			}
		}

		public Transform[] GetSpawnPoints()
		{
			return _spawnPoints;
		}
		
		public void UnregisterStranger(GameObject stranger)
		{
			_strangers.Remove(stranger);
		}
	}
}
