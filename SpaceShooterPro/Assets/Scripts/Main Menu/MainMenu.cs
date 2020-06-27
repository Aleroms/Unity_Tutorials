using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void LoadLevel()
	{
		SceneManager.LoadScene("Game");
	}
	public void LoadCoOp()
	{
		SceneManager.LoadScene("Co-opPlayer");
	}
	public void LoadSinglePlayer()
	{
		SceneManager.LoadScene("SinglePlayer");
	}
  //load the main menu
}
