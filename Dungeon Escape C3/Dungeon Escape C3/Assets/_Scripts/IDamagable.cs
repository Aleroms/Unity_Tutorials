using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//every script that implements this interface has to 
//use these methods
public interface IDamagable
{
	//interfaces cannot contain constants, i.e variables
	//must use auto-properties i.e {get, set}
	int Health { get; set; }
	void Damage();

}