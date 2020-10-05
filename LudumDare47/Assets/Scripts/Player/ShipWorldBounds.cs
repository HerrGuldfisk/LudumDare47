﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWorldBounds : MonoBehaviour
{
	public float xMax;
	public float yMax;
	Vector2 pos;

    // Update is called once per frame
    void Update()
    {
		pos = transform.position;

		if (pos.x > xMax)
		{
			Vector3 offset = LocalCameraPos();
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x * -1 + 0.5f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
			Camera.main.transform.position = this.gameObject.transform.position + offset;
		}

		if (pos.x < -xMax)
		{
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x * -1 - 0.5f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
		}


		if (pos.y > yMax)
		{
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y * -1 + 0.5f, this.gameObject.transform.position.z);
		}

		if (pos.y < -yMax)
		{
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y * -1 + 0.5f, this.gameObject.transform.position.z);
		}
	}

	Vector3 LocalCameraPos()
	{
		Vector3 camPos = Camera.main.transform.position;
		return camPos - transform.position;
	}
}
