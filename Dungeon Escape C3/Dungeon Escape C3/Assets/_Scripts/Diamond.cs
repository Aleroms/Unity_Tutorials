using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
	public int valueOfDiamond = 1;

	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			//add value worth
			Player p = other.GetComponent<Player>();
			
			//item collected
			if(p != null)
			{
				p.diamonds += valueOfDiamond;
				Destroy(gameObject);
			}
		}
	}
}
