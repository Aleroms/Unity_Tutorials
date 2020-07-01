using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
	[SerializeField]
	private Transform _respawnPoint;

    void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			Player player = GameObject.Find("Player").GetComponent<Player>();
			CharacterController cc = other.GetComponent<CharacterController>();

			if (player != null)
				player.Damage();

			if (cc != null)
				cc.enabled = false;

			other.transform.position = _respawnPoint.position;
			StartCoroutine(CCEnableRoutine(cc));
		}
	}
	IEnumerator CCEnableRoutine(CharacterController cc)
	{
		yield return new WaitForSeconds(0.25f);

		if (cc != null)
			cc.enabled = true;
	}
}
