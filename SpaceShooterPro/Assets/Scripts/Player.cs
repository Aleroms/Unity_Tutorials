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
	private float _offset = 0.8f;
	[SerializeField]
	private float _fireRate = 0.5f;
	private float _canFire = -1f;
	[SerializeField]
	private int _lives = 3;

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
			Instantiate(_laserPrefab, transform.position + new Vector3(0, _offset), Quaternion.identity);
	}
	void CalculateMethod()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		//Challenge Code: Initial implementation
		/*Vector3 horizontal = Vector3.right * _speed * Time.deltaTime * horizontalInput;
		Vector3 vertical = Vector3.up * _speed * Time.deltaTime * verticalInput;
		transform.Translate(horizontal + vertical);*/

		//Challenge Code: Better Code
		Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
		transform.Translate(direction * _speed * Time.deltaTime);

		//Challenge Code: Initial implementation
		//the code defines the boundaries that the player can be in
		//it also wraps if player leaves the horizontal boundary
		/*if (transform.position.y >= 2)
		{
			transform.position = new Vector3(transform.position.x, 2, 0);
		}
		else if (transform.position.y <= -2.8f)
		{
			transform.position = new Vector3(transform.position.x, -2.8f, 0);
		}*/

		//Challenge: Better code
		transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -2.8f, 2), 0);

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
}
