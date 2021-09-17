using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Attack();
    }

    public override void Attack()
	{//overrides parent implementation
        base.Attack();//runs parent code before unique code
        Debug.Log("Spider attack");   
	}

	public override void Update()
	{
        Debug.Log("Spider updating");
    }
}
