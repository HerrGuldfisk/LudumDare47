using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float gravity;
    public Transform gravityCenter = null;
	public bool inAtmosphere;

    void Update()
    {
		if (gravity != 0 && gravityCenter != null)
		{
			Vector2 gravityVector = gravity * (gravityCenter.position - transform.position).normalized * Time.deltaTime;
			GetComponent<Rigidbody2D>().velocity += gravityVector;
		}
    }
}
