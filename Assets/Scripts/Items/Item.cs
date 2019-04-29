﻿using UnityEngine;

namespace Items {
	public class Item : ScriptableObject
	{
		[SerializeField, Header("Item")] protected string _name;
		[TextArea, SerializeField] protected string _description;
		[SerializeField] protected int _value;
		[SerializeField] protected Sprite _uiSprite;
	}
}
