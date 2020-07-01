using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	private Text _lives;
	private Text _coins;

	private GameObject _gameOverPanel;

	void Start()
	{
		_coins = GameObject.Find("CoinDisplay").GetComponent<Text>();
		_lives = GameObject.Find("LivesDisplay").GetComponent<Text>();
		_gameOverPanel = GameObject.Find("GameOver_panel");
		_coins.text = "Coins: " + 0;
		_lives.text = "Lives: " + 3;
		_gameOverPanel.SetActive(false);
	}
	//updateCoinDisplay
	public void UpdateCoinDisplay(int num)
	{
		_coins.text = "Coins: " + num;
	}
	public void UpdateLivesDisplay(int lives)
	{
		_lives.text = "Lives: " + lives;
	}
	public void GameOver()
	{
		_coins.gameObject.SetActive(false);
		_lives.gameObject.SetActive(false);
		_gameOverPanel.SetActive(true);
	}
    
}
