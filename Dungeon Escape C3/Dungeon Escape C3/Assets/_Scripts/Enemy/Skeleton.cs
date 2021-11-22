using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamagable
{
	public int Health { get; set; }
	public override void Init()
	{
		base.Init();
		Health = base.health;
	}
	public override void Movement()
	{
		base.Movement();

	
	}
	public void Damage()
	{
		if (isDead) return;
		Debug.Log("Skeleton::Damage()");
		Health--;
		animator.SetTrigger("Hit");
		isHit = true;
		animator.SetBool("inCombat", true);

		Debug.Log(Health);
		if (Health < 1)
		{
			isDead = true;
			animator.SetTrigger("Death");

			GameObject diamond = Instantiate(diamonds, transform.position, Quaternion.identity);
			 diamond.GetComponent<Diamond>().valueOfDiamond = 3;
		}
	}
}
