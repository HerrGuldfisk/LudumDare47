using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFinder : MonoBehaviour
{
	CircleCollider2D searchRange;
	public float searchRadius;
	GameObject[] planets;

    // Start is called before the first frame update
    void Start()
    {
		searchRange = GetComponent<CircleCollider2D>();
		searchRange.radius = searchRadius;
    }

    // Update is called once per frame
    void Update()
    {

    }

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Planets"))
		{
			/*
			if (collision.GetComponent<Renderer>().isVisible == false)
			{

			}

			if (collision.GetComponent<Renderer>().isVisible == true)
			{

			}
			Transform planet = collision.transform;
			Vector2 direction = planet.position - transform.position;
			direction = direction.normalized;
			float scaleFactor = Camera.main.orthographicSize;
			Vector2 position = direction * scaleFactor;
			Debug.Log(collision.name + " " + position);
			*/
		}

	}
}
