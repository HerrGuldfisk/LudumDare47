using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickupMagnet : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ship"))
		{
			GetComponentInParent<FuelMovementScript>().chasePlayer = true;
			GetComponentInParent<FuelMovementScript>().FindPlayer(collision.transform);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Ship"))
		{
			GetComponentInParent<FuelMovementScript>().chasePlayer = false;
		}
	}
}
