using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public Transform target;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == target)
        {
            if (collision.GetComponent<shipResources>())
            {
                collision.GetComponent<shipResources>().addResource();
            }

            if (collision.GetComponentInParent<EarthResources>())
            {
                collision.GetComponentInParent<EarthResources>().addResource();
            }

            Destroy(this.gameObject);
        }
    }
}
    