using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
	public static UIManager Instance
	{
		get
		{
			
				return _instance;
			
		}
	}
	public Text playerGemCount;
	public Text gemCountText;
	public Image selectionSlider;
	public Image[] healthbar;
	

	
	private void Awake()
	{
		_instance = this;
	}

	public void OpenShop(int gemCount)
	{
		playerGemCount.text = gemCount + "G";
	}
	public void UpdateShopSelectioin(int yPos)
	{
		selectionSlider.rectTransform.anchoredPosition = new Vector2(selectionSlider.rectTransform.anchoredPosition.x, yPos);
	}
	public void UpdateGemCount(int count)
	{
		gemCountText.text = count.ToString();
	}

	public void UpdateLives(int health)
	{
		for(int i = 0; i <= health; i++)
		{
			if(i == health)
			{
				healthbar[i].enabled = false;
			}
		}
	}
}
