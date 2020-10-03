using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickupScript : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            Debug.Log("Picking up " + gameObject.name);
            GameManager.currentFuel += 15;
            Destroy(this.gameObject);
        }
    }
}
