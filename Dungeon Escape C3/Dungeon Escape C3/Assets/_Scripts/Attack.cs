using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	private bool _CanAttack = true;
	private void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log("Hit:" + other.name);

		IDamagable hit = other.GetComponent<IDamagable>();

		if(hit != null)
		{
			if(_CanAttack)
			{
				StartCoroutine(AttackCooldown());
				hit.Damage();
			}
		}
	}
	private IEnumerator AttackCooldown()
	{
		_CanAttack = false;
		yield return new WaitForSeconds(0.5f);
		_CanAttack = true;
	}
}
