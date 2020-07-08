using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private CharacterController _controller;
	[SerializeField]
	private float _speed = 5f;
	private float _gravity = 9.81f;

	private AudioSource _audioSource;

	[SerializeField]
	private GameObject _muzzleFire;
	[SerializeField]
	private GameObject _hitMarkerPrefab;
	[SerializeField]
	private GameObject _weapon;

	private int _currentAmmo;
	private int _maxAmmo = 50;
	private bool _coins = false;

	private bool _isReloading = false;


	private UIManager _uiManager;
	// Use this for initialization
	void Start () {

		_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

		if (_uiManager == null)
			Debug.LogError("UIManager is null");

		_currentAmmo = _maxAmmo;

		Cursor.lockState = CursorLockMode.Locked;
		_controller = GetComponent<CharacterController>();

		_audioSource = GetComponent<AudioSource>();

		if (_audioSource == null)
			Debug.LogError("AudioSource is null");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton(0) && _currentAmmo > 0)
		{
			
			Shoot();
			
		}
		else
		{
			_muzzleFire.SetActive(false);
			_audioSource.Stop();
		}

		if (Input.GetKeyDown(KeyCode.R) && !_isReloading)
		{
			_isReloading = true;
			StartCoroutine(Reload());
		}

		if (Input.GetKeyDown(KeyCode.Escape))
			Cursor.lockState = CursorLockMode.None;

		CalculateMovement();
	}
	void Shoot()
	{

		_muzzleFire.SetActive(true);
		_currentAmmo--;
		_uiManager.UpdateAmmoCount(_currentAmmo);
		if (!_audioSource.isPlaying)
			_audioSource.Play();

		Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
		RaycastHit hitInfo;

		if (Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity))
		{
			GameObject hit = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
			Destroy(hit, 0.2f);

			Destructable crate = hitInfo.transform.GetComponent<Destructable>();

			if(crate != null)
			{
				crate.DestroyCrate();
			}

		}
		

		//print(hitInfo.transform.name);
	}
	void CalculateMovement()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		Vector3 direction = new Vector3(x, 0, z);
		Vector3 velocity = direction * _speed;
		velocity.y -= _gravity;

		velocity = transform.TransformDirection(velocity);
		_controller.Move(velocity * Time.deltaTime * _speed);
	}
	IEnumerator Reload()
	{
		yield return new WaitForSeconds(1.5f);
		_currentAmmo = _maxAmmo;
		_uiManager.UpdateAmmoCount(_currentAmmo);
		_isReloading = false;
	}
	public void CoinAdd()
	{
		_coins = true;
	}
	public bool HasCoin()
	{
		return _coins;
	}
	public void CoinSub()
	{
		_coins = false;
	}
	public void WeaponEnable()
	{
		_weapon.SetActive(true);
	}
}
