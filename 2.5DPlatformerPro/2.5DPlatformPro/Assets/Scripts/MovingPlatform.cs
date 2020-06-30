﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	[SerializeField]
	private Transform _pointA, _pointB;
	private float _speed = 3f;
	private bool _switch = true;

    // Update is called once per frame
    void FixedUpdate()
    {
		if(_switch)
		{
			transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _speed * Time.deltaTime);

			if (transform.position == _pointB.position)
				_switch = false;
			
		}
		if(!_switch)
		{
			transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _speed * Time.deltaTime);

			if(transform.position == _pointA.position)
				_switch = true;
			
		}

    }
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			other.transform.SetParent(this.transform);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			other.transform.SetParent(null);
		}
	}
}
//collision detection
//collide with player
//take player parent and assign it to this.gameObj
//exit collision
//check if player exit
//player parent = null;