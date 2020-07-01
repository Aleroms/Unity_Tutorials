using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	private CharacterController _controller;

	[SerializeField]
	private float _speed = 5f;
	[SerializeField]
	private float _gravity = 9.81f;
	[SerializeField]
	private float _jumpHeight = 15f;
	private float _yVelocity;

	private int _coins = 0;
	[SerializeField]
	private int _lives = 3;

	private bool _canDoubleJump = true;
	private bool _isGameOver = true;

	private UIManager _UIManager;
 
    void Start()
    {
		_controller = GetComponent<CharacterController>();

		_UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

		if (_UIManager == null)
			Debug.LogError("UIManager reference is null");

		_UIManager.UpdateLivesDisplay(_lives);
	}
	//fall off map -> restart at spawn
	//fall ? lives-- : lives < 0 restart game
  
    void Update()
    {
		CalculateMovement();

		if(_isGameOver)
		{
			if(Input.GetKeyDown(KeyCode.R))
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		}
		/*
		if(transform.position.y < -10)
		{
			
			if(_lives == 0)
			{
				_UIManager.GameOver();
				//probably going to need game manager: here is good for now.
				Time.timeScale = 0;
				if (Input.GetKeyDown(KeyCode.R))
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
			else
			{
				//spawn point
				transform.position = new Vector3(-8f, 0);
				_lives--;
				_UIManager.UpdateLivesDisplay(_lives);
			}
		}*/
	}
	void CalculateMovement()
	{
		float horizontal = Input.GetAxis("Horizontal");
		Vector3 direction = new Vector3(horizontal, 0);
		Vector3 velocity = direction * _speed;

		if (_controller.isGrounded)
		{
			_canDoubleJump = true;

			if (Input.GetKeyDown(KeyCode.Space))
				_yVelocity = _jumpHeight;
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump)
			{
				_yVelocity += _jumpHeight;
				_canDoubleJump = false;
			}
			_yVelocity -= _gravity;
		}
		velocity.y = _yVelocity;
		_controller.Move(velocity * Time.deltaTime);
	}
	public void IncreaseCoins()
	{
		_coins++;
		_UIManager.UpdateCoinDisplay(_coins);
	}
	public void Damage()
	{
		_lives--;
		_UIManager.UpdateLivesDisplay(_lives);

		if (_lives < 1)
		{
			_isGameOver = true;
			_UIManager.GameOver();
		}
	}
}
