using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private float _speed = 4f;
	[SerializeField]
	private float _respawnBoundaryX = 10.6f;
   
   
    void Update()
    {
		transform.Translate(new Vector3(0, -1, 0) * _speed * Time.deltaTime);
        

		//if outside of screen
		if(transform.position.y <= -5)
		{
			float x = Random.Range(-1 * _respawnBoundaryX, _respawnBoundaryX);
			transform.position = new Vector3(x , 8, 0);
		}
		
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		//it's better to use other.tag than other.gameObject.tag
		if(other.tag == "Player")
		{
			Player player = other.transform.GetComponent<Player>();

			if(player != null)
			{
				player.Damage();
			}

			Destroy(this.gameObject);
		}
		else if(other.tag == "Laser")
		{
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
	}
}
