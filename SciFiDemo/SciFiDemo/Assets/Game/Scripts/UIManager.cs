using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	[SerializeField]
	private Text _ammoText;
	[SerializeField]
	private Text _coinDisplay;
	[SerializeField]
	private Text _weaponPrompt;
	[SerializeField]
	private GameObject _coin;

	void Start()
	{
		_ammoText.text = "Ammo: 50";
		_coinDisplay.gameObject.SetActive(false);
		_coin.SetActive(false);
		_weaponPrompt.gameObject.SetActive(false);
	}
	public void UpdateAmmoCount(int n)
	{
		_ammoText.text = "Ammo: " + n;
	}
	public void CoinDisplay(bool t)
	{
		if (t)
			_coinDisplay.gameObject.SetActive(true);
		
		else
			_coinDisplay.gameObject.SetActive(false);
		
	}
	public void CoinAdd()
	{
		_coin.SetActive(true);
		StartCoroutine(CoinTextDisplayOff());
	}
	IEnumerator CoinTextDisplayOff()
	{
		yield return new WaitForSeconds(0.5f);
		_coinDisplay.gameObject.SetActive(false);
	}
	public void WeponDisplay()
	{
		_weaponPrompt.gameObject.SetActive(true);
		//_coin.SetActive(false);
	}
	public void WeaponPurchase()
	{
		_coin.SetActive(false);
		StartCoroutine(WeaponPromptDisplayOff());
	}
	IEnumerator WeaponPromptDisplayOff()
	{
		yield return new WaitForSeconds(0.5f);
		_weaponPrompt.gameObject.SetActive(false);
	}
}
