using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject followTarget;

	private float smoothSpeed = 0.035f;
	public float planetZoom = 50f;
	public float shipZoom = 120f;
	private float zoomGoal;
	private float currentZoom = 50f;
	private float shipSpeed;
	private GameObject ship;

	// Update is called once per frame
	void FixedUpdate()
	{
		if (!GameManager.Instance.isRunning)
		{
			return;
		}

		ZoomLevel();
		MoveTowards(followTarget.transform);
	}

	void ZoomLevel()
	{
		if (!GameManager.Instance.isRunning)
		{
			return;
		}

		if (followTarget.CompareTag("Ship"))
		{
			zoomGoal = shipZoom;
		}
		if (followTarget.CompareTag("Orbit"))
		{
			zoomGoal = planetZoom;
		}

		if (shipZoom == 1500f)
		{
			currentZoom = Mathf.Lerp(currentZoom, zoomGoal, smoothSpeed * 0.1f);
		}
		else
		{
			currentZoom = Mathf.Lerp(currentZoom, zoomGoal, smoothSpeed);
		}

		Camera.main.orthographicSize = currentZoom;
	}

	private void Start()
	{
		ship = GameObject.FindGameObjectWithTag("Ship");
	}

	public void MoveTowards(Transform target)
	{
		shipSpeed = Mathf.Pow(Mathf.Log10(ship.GetComponent<ShipController>().rb.velocity.magnitude), 2) / 2;
		Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, -900);
		Vector3 smoothedPosition;

		if (followTarget.CompareTag("Ship"))
		{
			smoothedPosition = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -900), desiredPosition, smoothSpeed * shipSpeed);
			transform.position = smoothedPosition;
		}
		else
		{
			smoothedPosition = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -900), desiredPosition, smoothSpeed);
			transform.position = smoothedPosition;
		}

	}
}
