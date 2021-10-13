using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
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
