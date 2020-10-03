using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyTimer : MonoBehaviour
{
    [SerializeField] float destructionTime;
    private float timer;

    void Start()
    {
        timer = destructionTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
