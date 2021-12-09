using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public GameObject shopPanel;
	Player player;

	private int currentItemSelected;
	private int currentItemCost = 0;

	private void Start()
	{
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		UIManager.Instance.OpenShop(player.diamonds);
		

		if(collision.CompareTag("Player"))
			shopPanel.SetActive(true);
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
			shopPanel.SetActive(false);
	}
	public void SelectItem(int item)
	{
		//1  flames sword
		//2  boots
		//3  key
		
		switch(item)
		{
			case 1:
				UIManager.Instance.UpdateShopSelectioin(45);
				currentItemSelected = 1;
				currentItemCost = 200;
				break;
			case 2:
				UIManager.Instance.UpdateShopSelectioin(-31);
				currentItemSelected = 2;
				currentItemCost = 400;
				break;
			case 3:
				UIManager.Instance.UpdateShopSelectioin(-131);
				currentItemSelected = 3;
				currentItemCost = 100;
				break;
		}
	}
	public void BuyItem()
	{
		
		if(player.diamonds >= currentItemCost)
		{
			if(currentItemSelected == 3)
			{
				GameManager.Instance.hasKeyToCastle = true;
			}
			//give player goods
			player.diamonds -= currentItemCost;
		}
		else
		{
			Debug.Log("Notgood");
			shopPanel.SetActive(false);
		}
	}


}
