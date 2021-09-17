using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordAnim;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordAnim = transform.GetChild(1).GetComponent<Animator>();
        //getChild is hiearical structure; starts at top=0 and goes down
    }

    public void Movement(float movement)
	{
        //set float movement
        _anim.SetFloat("Horizontal",Mathf.Abs(movement));
	}
    public void Jumping(bool state)
	{
        _anim.SetBool("Jumping",state);
	}
    public void Attack()
	{
        _anim.SetTrigger("Attack");
        _swordAnim.SetTrigger("SwordAnimation");
	}
}
