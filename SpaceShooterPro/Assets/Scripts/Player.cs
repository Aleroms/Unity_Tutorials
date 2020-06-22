using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private float _speed = 3.5f;
	[SerializeField]
	private float _boundaryX = 10.6f;
	[SerializeField]
	private GameObject _laserPrefab;
	[SerializeField]
	private GameObject _tripleShotPrefab;
	[SerializeField]
	private float _fireRate = 0.5f;
	private float _canFire = -1f;
	[SerializeField]
	private float _speedboostMultiplier = 2;
	[SerializeField]
	private int _lives = 3;
	[SerializeField]//for testing purposes
	private bool _tripleShotEnable = false;
	[SerializeField]
	private bool _speedBoostEnable = false;
	[SerializeField]
	private float _tripleShotCooldown = 5f;
	[SerializeField]
	private float _speedboostCooldown = 5f;

	private SpawnManager _manager;
	//use _ to denote that variable is private
   
    void Start()
    {
		transform.position = new Vector3(0, 2, 0);
		_manager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

		if(_manager == null)
		{
			Debug.LogError("Spawn Manager is NULL");
		}
	}

  
    void Update()
    {
		CalculateMethod();

		if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
		{
			FireLaser();
		}
    }
	void FireLaser()
	{
			_canFire = Time.time + _fireRate;

		if (_tripleShotEnable)
			Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
		else
			Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.06f), Quaternion.identity);

		
	}
	void CalculateMethod()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		//move the player
		Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
		
		transform.Translate(direction * _speed * Time.deltaTime);

		//y-axis boundary
		transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -2.8f, 2), 0);


		//if out of range wrap the player
		if (transform.position.x >= _boundaryX)
		{
			transform.position = new Vector3(-1 * _boundaryX, transform.position.y, 0);
		}
		else if (transform.position.x < -1 * _boundaryX)
		{
			transform.position = new Vector3(_boundaryX, transform.position.y, 0);
		}
	}
	public void Damage()
	{
		_lives--;
		
		if(_lives < 1)
		{
			//let SpawnManager know to stop spawning
			_manager.OnPlayerDeath();
			Destroy(this.gameObject);
		}
	}
	public void TripleShotActive()
	{
		_tripleShotEnable = true;
		StartCoroutine(TripleShotCoroutine());
	}
	IEnumerator TripleShotCoroutine()
	{
		yield return new WaitForSeconds(_tripleShotCooldown);
		_tripleShotEnable = false;
	}
	public void SpeedBostActive()
	{
		_speed *= _speedboostMultiplier;
		_speedBoostEnable = true;
		StartCoroutine(SpeedBoostCoroutine());
	}
	IEnumerator SpeedBoostCoroutine()
	{
		yield return new WaitForSeconds(_speedboostCooldown);
		_speedBoostEnable = false;
		_speed /= _speedboostMultiplier;
	}
}
