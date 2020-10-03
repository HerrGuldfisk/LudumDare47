using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float gravity;
    public Transform gravityCenter = null;

    void Update()
    {
		if (gravity != 0 && gravityCenter != null)
		{
			Vector2 gravityVector = gravity * Time.deltaTime * (gravityCenter.position - transform.position);
			GetComponent<Rigidbody2D>().velocity += gravityVector;
		}
    }
}
