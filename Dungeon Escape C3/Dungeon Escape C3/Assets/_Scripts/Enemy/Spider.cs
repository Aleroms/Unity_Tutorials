using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{
	public GameObject acidEffectPrefab;

	public int Health { get; set; }
	//use for Initialization

	public override void Update()
	{
		
	}
	public override void Init()
	{
		base.Init();

		Health = base.health;
	}
	public override void Movement()
	{
		
	}
	public void Damage()
	{
		if (isDead) return;
		Health--;
		if (Health < 1)
		{
			isDead = true;
			animator.SetTrigger("Death");

			GameObject diamond = Instantiate(diamonds, transform.position, Quaternion.identity);
			diamond.GetComponent<Diamond>().valueOfDiamond = 1;
		}
	}
	public void Attack()
	{
		Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
	}
}
