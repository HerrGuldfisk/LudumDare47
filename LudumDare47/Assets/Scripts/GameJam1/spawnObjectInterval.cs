using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObjectInterval : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] float timeBetweenSpawns;
    private float timer;

    void Start()
    {
        timer = timeBetweenSpawns;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Object.Instantiate(objectToSpawn, transform.position, transform.rotation);
            timer = timeBetweenSpawns;
        }
    }
}
