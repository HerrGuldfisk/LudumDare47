using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnCollisionWithTagged : MonoBehaviour
{
    [SerializeField] string[] tags;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(string tag in tags)
        {
            if (collision.CompareTag(tag))
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (string tag in tags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
