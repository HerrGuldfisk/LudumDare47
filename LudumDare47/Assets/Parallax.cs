using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
	Camera cam;
	Vector3 previousPos;
	public float factor = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
		cam = Camera.main;
		previousPos = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		transform.position += (cam.transform.position - previousPos) * factor;
		previousPos = cam.transform.position;
    }
}
