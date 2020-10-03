using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform target;

    private float smoothSpeed = 0.08f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, -100);
        Vector3 smoothedPosition = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -100), desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	}
}
