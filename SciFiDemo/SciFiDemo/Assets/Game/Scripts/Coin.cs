using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	[SerializeField]
	private AudioClip _coinPickup;
	private UIManager _uim;
	private Player _pl;

	void Start()
	{

		if (_coinPickup == null)
			Debug.LogError("Audio Source is null");

		_uim = GameObject.Find("Canvas").GetComponent<UIManager>();

		if (_uim == null)
			Debug.LogError("UIManger is null");

		_pl = GameObject.Find("Player").GetComponent<Player>();

		if(_pl == null)
			Debug.LogError("Player Script is null");
	}
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			_uim.CoinDisplay(true);

			if (Input.GetKeyDown(KeyCode.E))
			{
				_uim.CoinAdd();
				Destroy(this.gameObject);
				_pl.CoinAdd();
				AudioSource.PlayClipAtPoint(_coinPickup, transform.position);
			}
		}
	}

}
