﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
	CircleCollider2D atmosphere;
	GravityController ship;
	public float gravity;

    // Start is called before the first frame update
    void Start()
    {
		atmosphere = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

	private void FixedUpdate()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ship"))
		{
			collision.GetComponent<GravityController>().gravityCenter = transform;
			collision.GetComponent<GravityController>().gravity = gravity;
			collision.GetComponent<GravityController>().inAtmosphere = true;
			collision.GetComponent<ShipController>().EnterOrbitSound();
			collision.GetComponent<LampController>().TurnOffLamps();
			Camera.main.GetComponent<CameraFollow>().followTarget = gameObject;
			Camera.main.GetComponent<CameraFollow>().planetZoom = transform.localScale.x * GetComponent<CircleCollider2D>().radius * 1.25f;
			// ship.gravity = gravity;
			// ship.gravityCenter = transform;
			GameManager.inOrbit = true;
			//Debug.Log("Entering planet orbit " + collision.GetComponent<GravityController>().gravity);
		}

		if (collision.CompareTag("FuelRefill"))
		{
			collision.GetComponent<FuelMovementScript>().EnterOrbit(transform);
		}
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Ship"))
		{
			ship = collision.GetComponent<GravityController>();
			collision.GetComponent<GravityController>().inAtmosphere = false;
			collision.GetComponent<ShipController>().ExitOrbitSound();
			collision.GetComponent<LampController>().TurnOnLamps();
			ship.gravity = 0;
			Camera.main.GetComponent<CameraFollow>().followTarget = collision.gameObject;
			GameManager.inOrbit = false;
		}

		if (collision.CompareTag("FuelRefill"))
		{
			collision.GetComponent<FuelMovementScript>().ExitOrbit();
		}
	}
}
