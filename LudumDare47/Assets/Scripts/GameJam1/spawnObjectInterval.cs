using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObjectInterval : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] float timeBetweenSpawns;
    private float timer;
    private bool isSpawning;

    void Start()
    {
        timer = timeBetweenSpawns;
    }

    void Update()
    {
        if (isSpawning)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                Object.Instantiate(objectToSpawn, transform.position, transform.rotation);
                timer = timeBetweenSpawns;
            }
        }
    }

    public void startSpawning(float interval)
    {
        isSpawning = true;
        timeBetweenSpawns = interval;
    }

    public void stopSpawning()
    {
        isSpawning = false;
    }
}
