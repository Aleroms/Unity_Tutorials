using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//you can only inheret from 1 but you can implement many interfaces
public class MossGiant : Enemy, IDamagable
{
	
	public int Health { get; set; }
	//use for Initialization
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
		Debug.Log("MossGiant::Damage()");
		Health--;
		animator.SetTrigger("Hit");
		isHit = true;
		animator.SetBool("inCombat", true);
		if (Health < 1)
		{
			isDead = true;
			animator.SetTrigger("Death");

			GameObject diamond = Instantiate(diamonds, transform.position, Quaternion.identity);
			diamond.GetComponent<Diamond>().valueOfDiamond = 5;
		}
	}


}
