﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [SerializeField] float startSpeed = 2;
	[SerializeField] float accAmount = 4;
    [SerializeField] float fuelCostGas = 5;
    [SerializeField] float fuelCostTurn = 2;

    [SerializeField] AudioClip accSound;
    [SerializeField] AudioClip breakSound;
    [SerializeField] AudioClip accLoopSound;
    [SerializeField] AudioClip breakLoopSound;
    [SerializeField] AudioClip enterSound;
    [SerializeField] AudioClip exitSound;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip suckSound;

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
            Vector2 gasVector = gas.ReadValue<Vector2>();
            Vector2 directon = rb.velocity.normalized;
            rb.AddForce(directon * gasVector.y * accAmount);
            rb.AddForce(new Vector2(directon.y , -directon.x) * gasVector.x * accAmount * 4f);
            fuelSystem.DepleteFuel((Mathf.Abs(gasVector.y)*fuelCostGas  + Mathf.Abs(gasVector.x)*fuelCostTurn)*Time.deltaTime);

            if (gas.ReadValue<Vector2>().y > 0)
            {
                //audioManager.PlayOneshot(accSound);
                audioManager.playSound(accLoopSound);
            }
            else if (gas.ReadValue<Vector2>().y < 0)
            {
                //audioManager.PlayOneshot(breakSound);
                audioManager.playSound(breakLoopSound);
            }
        }

        if (gas.ReadValue<Vector2>().y == 0)
        {
            StopEngineSounds();
        }
    }

    public void CrashSound()
    {
        StopEngineSounds();
        audioManager.PlayOneshot(crashSound);
    }

    public void EnterOrbitSound()
    {
        //StopEngineSounds();
        audioManager.PlayOneshot(enterSound);
    }

    public void ExitOrbitSound()
    {
        //StopEngineSounds();
        audioManager.PlayOneshot(exitSound);
    }

    public void StopEngineSounds()
    {
        audioManager.stopPlaying(accSound);
        audioManager.stopPlaying(accLoopSound);
        audioManager.stopPlaying(breakSound);
        audioManager.stopPlaying(breakLoopSound);
    }

    public void PlaySuckSound()
    {
        audioManager.playSound(suckSound);
    }

    public void StopSuckSound()
    {
        audioManager.stopPlaying(suckSound);
    }
}
