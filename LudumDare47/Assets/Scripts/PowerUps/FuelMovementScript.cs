using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelMovementScript : MonoBehaviour
{
    Rigidbody2D rb;

    private float startSpeed;
    private Vector2 startDir;
    private float currentDir;
    public bool inOrbit;
    private Transform rotationCenter = null;

    // Start is called before the first frame update
    void Start()
    {
        startSpeed = Random.Range(2f, 4f);
        startDir = Random.insideUnitCircle.normalized;

        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = Random.Range(-10f, 10f);
        rb.velocity = startDir * startSpeed;
    }

    public void EnterOrbit(Transform rc)
    {
        rotationCenter = rc;
        inOrbit = true;
    }

    public void ExitOrbit()
    {
        inOrbit = false;
    }

    private void FixedUpdate()
    {
        if (inOrbit)
        {
            // Might want to use to rotate best direction
            /*
            if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
            {
                currentDir = rb.velocity.normalized.x;
            }
            else
            {
                currentDir = rb.velocity.normalized.y;
            }
            */

            transform.RotateAround(rotationCenter.position, new Vector3(0, 0, 1), startSpeed * Time.deltaTime);
        }
    }
}
