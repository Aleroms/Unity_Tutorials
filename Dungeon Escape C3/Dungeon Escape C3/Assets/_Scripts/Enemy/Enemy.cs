using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;//[] waypoints;

    protected Vector3 currentTarget;
    protected Animator animator;
    protected SpriteRenderer sprite;
	protected GameObject player;
	protected bool isHit = false;
	private void Start()
	{
		Init();
	}
	public virtual void Update()
	{
		//waits till idle.anim is done playing before moving monster
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && animator.GetBool("inCombat") == false)
			return;

		Movement();
	}
    public virtual void Init()
	{
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
		player = GameObject.Find("Player");
    }
    public virtual void Movement()
	{
		if (currentTarget == pointA.position)
			sprite.flipX = true;
		else if (currentTarget == pointB.position)
			sprite.flipX = false;

		float step = speed * Time.deltaTime;

		if (transform.position == pointA.position)
		{
			currentTarget = pointB.position;
			animator.SetTrigger("Idle");

		}
		else if (transform.position == pointB.position)
		{
			currentTarget = pointA.position;
			animator.SetTrigger("Idle");

		}

		if(!isHit)
			transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);

		float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
		if(distance > 2f)
		{
			isHit = false;
			animator.SetBool("inCombat", false);
		}
	}
    //public abstract void Update();
	//forces inherited objects to implement an override for Update()

	
}
