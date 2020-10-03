using System.Collections;
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
			Camera.main.GetComponent<CameraFollow>().followTarget = gameObject;
			// ship.gravity = gravity;
			// ship.gravityCenter = transform;
			Debug.Log("Entering planet orbit " + collision.GetComponent<GravityController>().gravity);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Ship"))
		{
			ship = collision.GetComponent<GravityController>();
			collision.GetComponent<GravityController>().inAtmosphere = false;
			ship.gravity = 0;
			Camera.main.GetComponent<CameraFollow>().followTarget = collision.gameObject;
			Debug.Log("Leaving planet orbit " + collision.GetComponent<GravityController>().gravity);
		}
	}
}
