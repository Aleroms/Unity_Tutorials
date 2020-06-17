using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	[SerializeField]
	private float _speed = 8f;
   
    // Update is called once per frame
    void Update()
    {
		//Challenge: Initial implementation
		//Vector3 direction = Vector3.up * _speed * Time.deltaTime;
		//transform.Translate(direction);

		//Challenge: better code
		transform.Translate(Vector3.up * _speed * Time.deltaTime);

		//Chalenge: Initial implementation
		if (transform.position.y >= 9)
			Destroy(gameObject);
    }
}
