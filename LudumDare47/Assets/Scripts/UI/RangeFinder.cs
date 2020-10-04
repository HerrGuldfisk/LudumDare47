using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFinder : MonoBehaviour
{
	CircleCollider2D searchRange;
	public float searchRadius;
	List<GameObject> planets;

	public GameObject arrow;
	Camera cam;

    // Start is called before the first frame update
    void Start()
    {
		searchRange = GetComponent<CircleCollider2D>();
		searchRange.radius = searchRadius;
		cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Planets"))
		{
			GameObject locator = Instantiate(arrow);
			planets.Add(locator);
			foreach(GameObject planet in planets)
			{
				Debug.Log(planet.name);
			}

		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		Transform shipLocation;
		shipLocation = FindObjectOfType<ShipController>().transform;
		Vector2 localShipPos;
		localShipPos = Camera.main.WorldToViewportPoint(shipLocation.position);

		Vector3 planet = collision.transform.position;

		Vector2 planetScreenPos = cam.WorldToViewportPoint(planet);
		if (planetScreenPos.x >= 0 && planetScreenPos.x <= 1 && planetScreenPos.y >= 0 && planetScreenPos.y <= 1)
		{
			return;
		}

		Vector2 arrowVector = planetScreenPos - localShipPos;


		/*
		Vector2 planetLocation = transform.position - planet;


		Vector2 direction =
			if (direction.magnitude >= Camera.main.orthographicSize)
			{
				direction = direction.normalized;
				float scaleFactor = Camera.main.orthographicSize / 2;
				Vector2 position = direction * scaleFactor;
				Debug.Log(collision.name + " " + position);
			}

		}*/
	}

	private void OnTriggerExit2D(Collider2D collision)
	{

	}
}
