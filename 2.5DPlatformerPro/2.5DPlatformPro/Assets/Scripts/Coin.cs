﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	private Player _player;

	void Start()
	{
		_player = GameObject.Find("Player").GetComponent<Player>();

		if (_player == null)
			Debug.LogError("Player reference is null");

		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			_player.IncreaseCoins();
			Destroy(gameObject);
			//_UIManager.UpdateCoinDisplay();
		}
	}
}
