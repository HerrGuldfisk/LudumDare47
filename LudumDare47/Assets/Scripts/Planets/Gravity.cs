using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
	CircleCollider2D atmosphere;
	GameObject ship;
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
			/*ship = collision.GetComponentInParent<ShipController>();
			ship.gravity = gravity;
			ship.inAtmosphere = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Ship"))
		{
			ship = collision.GetComponentInParent<ShipController>();
			ship.inAtmosphere = false;
			ship.gravity = 0;*/
		}
	}
}
