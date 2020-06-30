using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	private Player _player;
	UIManager _UIManager;

	void Start()
	{
		_player = GameObject.Find("Player").GetComponent<Player>();

		if (_player == null)
			Debug.LogError("Player reference is null");

		_UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

		if (_UIManager == null)
			Debug.LogError("UIManager reference is null");
	}
	//ontrigger enter
	//give player a coin
	//destroy
	//update ui
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			_player.IncreaseCoins();
			Destroy(gameObject);
			_UIManager.UpdateCoinDisplay();
		}
	}
}
