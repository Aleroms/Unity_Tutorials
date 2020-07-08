using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	[SerializeField]
	private Text _ammoText; 

	void Start()
	{
		_ammoText.text = "Ammo: 50";
	}
	public void UpdateAmmoCount(int n)
	{
		_ammoText.text = "Ammo: " + n;
	}
}
