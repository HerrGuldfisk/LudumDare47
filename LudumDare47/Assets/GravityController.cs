using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float gravity;
    public Transform gravityCenter;

    void Update()
    {
        Vector2 gravityVector = gravity * Time.deltaTime * (gravityCenter.position - transform.position)*0.2f;
        GetComponent<Rigidbody2D>().velocity += gravityVector;
    }
}
