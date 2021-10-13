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
	}
	public void Damage()
	{

	}


}
