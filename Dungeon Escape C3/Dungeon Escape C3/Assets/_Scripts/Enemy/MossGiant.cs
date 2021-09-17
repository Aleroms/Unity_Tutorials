using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
	public override void Update()
	{
		Debug.Log("Moss Giant updating");
	}

	// Start is called before the first frame update
	void Start()
    {
        Attack();
    }

}
