using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [SerializeField] float startSpeed = 2;
    [SerializeField] float accAmount = 1;
    private Rigidbody2D rb;
    public InputAction gas;

    private void OnEnable()
    {
        gas.Enable();
    }

    private void OnDisable()
    {
        gas.Disable();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(startSpeed, 0);
    }

    private void Update()
    {
        var dir = rb.velocity.normalized;

        rb.velocity += dir*gas.ReadValue<float>() * accAmount * Time.deltaTime;


        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
