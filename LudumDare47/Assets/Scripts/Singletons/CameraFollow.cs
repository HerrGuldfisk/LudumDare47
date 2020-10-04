using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject followTarget;

	private float smoothSpeed = 0.04f;
	private float planetZoom = 50f;
	private float shipZoom = 120f;
	private float zoomGoal;
	private float currentZoom = 50f;

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
		if (followTarget.CompareTag("Ship"))
		{
			zoomGoal = shipZoom;
		}
		if (followTarget.CompareTag("Orbit"))
		{
			zoomGoal = planetZoom;
		}
		currentZoom = Mathf.Lerp(currentZoom, zoomGoal, smoothSpeed);
		Camera.main.orthographicSize = currentZoom;
	}

	void MoveTowards(Transform target)
	{
		Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, -100);
		Vector3 smoothedPosition = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -100), desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	}
}
