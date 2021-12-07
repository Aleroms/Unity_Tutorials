using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public GameObject shopPanel;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Player player = collision.GetComponent<Player>();
		if(player != null)
		{
			UIManager.Instance.OpenShop(player.diamonds);
		}

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
				break;
			case 2:
				UIManager.Instance.UpdateShopSelectioin(-31);
				break;
			case 3:
				UIManager.Instance.UpdateShopSelectioin(-131);
				break;
		}
	}


}
