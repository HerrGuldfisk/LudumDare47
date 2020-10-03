using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float gravity;
    public Transform gravityCenter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(speed * 0.01f, 0, 0);
        GetComponent<Rigidbody>().velocity += gravity * Time.fixedTime * (gravityCenter.position - transform.position);
    }
}
