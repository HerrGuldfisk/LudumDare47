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
            if (GameManager.currentFuel < GameManager.maxFuel)
            {
                GameManager.currentFuel += 15;
                if (GameManager.currentFuel > GameManager.maxFuel)
                {
                    GameManager.currentFuel = GameManager.maxFuel;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
