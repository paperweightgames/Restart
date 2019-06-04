using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
	public class InteractionTransmitter : MonoBehaviour
	{
		[SerializeField] private InteractionObject _interaction;
		[SerializeField] private GameObject _player;
		private InteractionReceiver _interactionReceiver;

		public void SetPlayer(GameObject newPlayer)
		{
			_player = newPlayer;
		}
		
		private void Awake()
		{
			_interactionReceiver = _player.GetComponent<InteractionReceiver>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject == _player)
			{
				_interactionReceiver.AddInteraction(_interaction, gameObject);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject == _player)
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