using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

	private float startRotation;
	public float rotationSpeed  = 8f;

	public bool randomSpeed;
    // Start is called before the first frame update
    void Start()
    {
		startRotation = Random.Range(0f, 360f);
		transform.Rotate(0, 0, startRotation);

		if (randomSpeed)
		{
			rotationSpeed = Random.Range(-0.08f, 0.08f);
		}
    }

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(0, 0, rotationSpeed);
    }
}
