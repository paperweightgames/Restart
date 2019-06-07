using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
	public class InteractionTransmitter : MonoBehaviour
	{
		[SerializeField] private InteractionObject _interaction;
		[SerializeField] private GameObject _player;
		[SerializeField] private bool _isStranger = true;
		private InteractionReceiver _interactionReceiver;
		private PlayerInteracting _playerInteracting;

		private void Awake()
		{
			if (_player != null)
			{
				SetPlayer(_player);
			}
		}

		public void SetPlayer(GameObject newPlayer)
		{
			_player = newPlayer;
			_interactionReceiver = _player.GetComponent<InteractionReceiver>();
			_playerInteracting = _player.GetComponent<PlayerInteracting>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.isTrigger) return;
			
			if (other.gameObject != _player) return;
			
			if (_playerInteracting.IsBegging() == null || !_isStranger)
			{
				
				_interactionReceiver.AddInteraction(_interaction, gameObject);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.isTrigger) return;
			
			if (other.gameObject != _player) return;
			
			if (_playerInteracting.IsBegging() == gameObject || !_isStranger)
			{
				_interactionReceiver.RemoveInteraction(_interaction);
			}
		}

		private void OnDestroy()
		{
			// Remove the interaction on de spawn.
			if (_interactionReceiver == null) return;
			_interactionReceiver.RemoveInteraction(_interaction);
		}

		public void SetInteraction(InteractionObject newInteraction)
		{
			_interaction = newInteraction;
		}
	}
}