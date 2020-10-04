using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashScript : MonoBehaviour
{

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Planet"))
		{
			GameManager.PlayerDeath();
			GetComponent<ShipController>().CrashSound();
			GetComponent<Death>().PlayerDeath("THE SHIP WAS OBLITERATED");
		}
	}
}
