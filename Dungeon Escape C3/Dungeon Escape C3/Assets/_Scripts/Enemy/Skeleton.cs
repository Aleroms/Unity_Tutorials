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
	public void Damage()
	{
		Debug.Log("Damage()");
		Health--;
		animator.SetTrigger("Hit");
		isHit = true;
		animator.SetBool("inCombat", true);
		if (Health < 1)
			Destroy(gameObject);
	}
}
