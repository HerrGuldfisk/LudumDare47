using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickupScript : MonoBehaviour
{
    float fuelRange;

    private void Awake()
    {
        fuelRange = Mathf.Round(Random.Range(15f,25f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            FuelSystem fuelscript = collision.GetComponent<FuelSystem>();

            if (GameManager.currentFuel < GameManager.maxFuel)
            {
                fuelscript.addFuel(15);
            }

            Destroy(transform.parent.gameObject);
        }
    }
}
