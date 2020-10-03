using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [SerializeField] float startSpeed = 2;
	[SerializeField] float accAmount = 1;
    [SerializeField] float fuelCost = 5;
    private Rigidbody2D rb;
    private FuelSystem fuelSystem;
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
        fuelSystem = GetComponent<FuelSystem>();
        rb.velocity = new Vector2(startSpeed, 0);
    }

    private void Update()
    {
        var dir = rb.velocity.normalized;

		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (gas.ReadValue<float>() != 0)
        {
            rb.velocity += dir * gas.ReadValue<float>() * accAmount * Time.deltaTime;
            fuelSystem.DepleteFuel(fuelCost*Time.deltaTime);
        }
    }

}
