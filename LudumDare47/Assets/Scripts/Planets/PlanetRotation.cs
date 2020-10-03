using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
	public float rotationSpeed;

	// Update is called once per frame
	private void Start()
	{

	}

	void Update()
    {
		transform.Rotate(new Vector3(1, 1, 1) * -rotationSpeed * Time.deltaTime);
    }
}
