﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    [SerializeField] float standbyDepletion = 1;
    private Slider fuelSlider;
    private bool shipTurnedOff = false;

    private void Awake()
    {
        GameManager.currentFuel = GameManager.maxFuel;
        fuelSlider = GameObject.FindGameObjectWithTag("fuelBar").transform.GetComponent<Slider>();
    }

    void Update()
    {
        if (GameManager.inOrbit)
        {
            GameManager.currentFuel -= standbyDepletion * Time.deltaTime;
        }
        
        updateSlider();

        if (!shipTurnedOff && GameManager.currentFuel < 0)
        {
            shipTurnedOff = true;
            GetComponent<ShipController>().gas.Disable();
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            FuelIsEmpty();
        }
    }

    public void DepleteFuel(float amount)
    {
        GameManager.currentFuel -= amount;
    }

    private void updateSlider()
    {
        fuelSlider.value = GameManager.currentFuel / GameManager.maxFuel;
    }

    private void FuelIsEmpty()
    {
        GameManager.PlayerDeath();
        GetComponent<Death>().PlayerDeath("Out of fuel...");
    }
}
