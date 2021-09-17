using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;

    public virtual void Attack()
	{ //virtual allows implementation of specific in inherited objects
        Debug.Log("My name is: " + this.gameObject.name);
	}
    public abstract void Update();
	//forces inherited objects to implement an override for Update()

	
}
