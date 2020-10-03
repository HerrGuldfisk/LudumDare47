using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{
    [SerializeField] float speed;

    void FixedUpdate()
    {
        transform.Translate(speed*0.01f, 0, 0);
    }
}
