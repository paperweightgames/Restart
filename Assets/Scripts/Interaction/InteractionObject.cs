using System;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction {
	[Serializable]
	public class InteractionObject
	{
		[SerializeField] private string _name;
		[SerializeField] private GameObject _sender;
		[SerializeField] private UnityEvent _action;

		public string GetName()
		{
			return _name;
		}
		public void Invoke()
		{
			_action.Invoke();
		}

		public void SetSender(GameObject newSender)
		{
			_sender = newSender;
		}

		public GameObject GetSender()
		{
			return _sender;
		}
	}
}
