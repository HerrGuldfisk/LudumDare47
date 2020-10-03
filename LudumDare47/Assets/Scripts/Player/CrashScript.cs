using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("planet"))
        {
            Debug.Log("Collision with " + collision.gameObject.name);

            GameManager.PlayerCrash();

            Destroy(this.gameObject);
        }
    }
}
