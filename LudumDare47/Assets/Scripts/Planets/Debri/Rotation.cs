using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

	private float startRotation;
	public float rotationSpeed  = 1f;

	public Transform rotationCenter;

	public bool randomSpeed = true;
    // Start is called before the first frame update
    void Start()
    {
		startRotation = Random.Range(0f, 360f);
		transform.Rotate(0, 0, startRotation);
		randomSpeed = true;

		if (randomSpeed)
		{
			rotationSpeed = 0.05f + Random.Range(-rotationSpeed, rotationSpeed);
		}
    }

    // Update is called once per frame
    void Update()
    {
		transform.RotateAround(rotationCenter.position, new Vector3(0, 0, 1), rotationSpeed);
		// transform.Rotate(0, 0, rotationSpeed);
    }
}
