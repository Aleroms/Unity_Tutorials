using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour {

	private Player _pl;
	private AudioSource _audiosource;
	private UIManager _uim;

	void Start()
	{
		_pl = GameObject.Find("Player").GetComponent<Player>();

		if (_pl == null)
			Debug.LogError("Player script is null");

		_audiosource = GetComponent<AudioSource>();

		_uim = GameObject.Find("Canvas").GetComponent<UIManager>();

		if (_uim == null)
			Debug.LogError("UIManager is null");
	}
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			_uim.WeponDisplay();

			if(Input.GetKeyDown(KeyCode.E))
			{
				if (_pl.HasCoin())
				{
					_uim.WeaponPurchase();
					_pl.WeaponEnable();
					_pl.CoinSub();
					_audiosource.Play();
				}
				else
					Debug.Log("Get out of my shop!");
			}
		}
	}
	
}
