﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private bool _isGameOver = false;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.R) && _isGameOver)
		{
			//current game scene 
			SceneManager.LoadScene(0);
		}
	}
	public void GameOver()
	{
		_isGameOver = true;
	}
}
