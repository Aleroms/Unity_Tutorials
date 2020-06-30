using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private bool _canDoubleJump = true;
    // Start is called before the first frame update
    void Start()
    {
		_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {//velocity is directions and speed
		float horizontal = Input.GetAxis("Horizontal");
		Vector3 direction = new Vector3(horizontal, 0);
		Vector3 velocity = direction * _speed;

		if(_controller.isGrounded)
		{
			_canDoubleJump = true;

			if (Input.GetKeyDown(KeyCode.Space))
				_yVelocity = _jumpHeight;
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.Space) && _canDoubleJump)
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
	}
}
