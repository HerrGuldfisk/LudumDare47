using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [SerializeField] float startSpeed = 2;
	[SerializeField] float accAmount = 4;
    [SerializeField] float fuelCost = 5;

    [SerializeField] AudioClip accSound;
    [SerializeField] AudioClip breakSound;

    private Rigidbody2D rb;
    private FuelSystem fuelSystem;
    private audioManager audioManager;
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
        audioManager = GameObject.FindGameObjectWithTag("AudioController").transform.GetComponent<audioManager>();
    }

    private void FixedUpdate()
    {
        var dir = rb.velocity.normalized;

		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (gas.ReadValue<Vector2>() != Vector2.zero)
        {
            rb.AddForce(rb.velocity.normalized * gas.ReadValue<Vector2>().y * accAmount);
            rb.AddForce(new Vector2(rb.velocity.normalized.y , -rb.velocity.normalized.x) * gas.ReadValue<Vector2>().x * accAmount * 4f);
            fuelSystem.DepleteFuel(fuelCost*Time.deltaTime);

            if (gas.ReadValue<Vector2>().y > 0)
            {
                audioManager.playSound(accSound);
            }
            else if (gas.ReadValue<Vector2>().y < 0)
            {
                audioManager.playSound(breakSound);
            }
        }

        if (gas.ReadValue<Vector2>().y == 0)
        {
            audioManager.stopPlaying(accSound);
            audioManager.stopPlaying(breakSound);
        }
    }

}
