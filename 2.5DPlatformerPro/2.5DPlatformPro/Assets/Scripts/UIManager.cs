using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	private Text _coins;
	private int _coinAmount = 0;

	void Start()
	{
		_coins = GameObject.Find("CoinDisplay").GetComponent<Text>();
		_coins.text = "Coins: " + _coinAmount;
	}
	//updateCoinDisplay
	public void UpdateCoinDisplay()
	{
		_coinAmount++;
		_coins.text = "Coins: " + _coinAmount;
	}
    
}
