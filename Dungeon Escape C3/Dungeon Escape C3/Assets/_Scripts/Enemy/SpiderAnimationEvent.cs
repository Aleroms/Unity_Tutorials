using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
	//get reference to spider
	private Spider _spider;

	private void Start()
	{
		_spider = transform.parent.GetComponent<Spider>();
	}
	public void Fire()
	{
		//tell the spider to fire
		_spider.Attack();
	}
}
