using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitDebris : MonoBehaviour
{
    public GameObject fuelPrefab;
    private int numFuel;

    public GameObject[] debrisPrefabs;
    private GameObject debrisPrefab;
    private int numDebris;

    CircleCollider2D collider;
    float radius;
    private float randomRadius;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        radius = collider.radius * transform.localScale.x;

        SpawnFuel();

        SpawnDebris();
    }

    private void SpawnFuel()
    {
        numFuel = Random.Range(1,5);

        for (int i = 0; i < numFuel; i++)
        {
            randomRadius = Random.Range(radius * 4f, radius * 8f);

            float angle = i * Mathf.PI * 2 / numFuel;
            float x = Mathf.Cos(angle) * randomRadius;
            float y = Mathf.Sin(angle) * randomRadius;
            Vector3 pos = transform.position + new Vector3(x, y, 0);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, 0, angleDegrees);

            if (fuelPrefab != null)
            {
                Instantiate(fuelPrefab, pos, rot);
            }
        }
    }

    private void SpawnDebris()
    {
        numDebris = Random.Range(0, 3);

        for (int i = 0; i < numDebris; i++)
        {
            randomRadius = Random.Range(radius * 2f, radius * 4f);

            float angle = i * Mathf.PI * 2 / numDebris;
            float x = Mathf.Cos(angle) * randomRadius;
            float y = Mathf.Sin(angle) * randomRadius;
            Vector3 pos = transform.position + new Vector3(x, y, 0);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, 0, angleDegrees);

            if (debrisPrefabs != null)
            {
                Instantiate(debrisPrefabs[Random.Range(0,debrisPrefabs.Length-1)], pos, rot);
            }
        }
    }
}
