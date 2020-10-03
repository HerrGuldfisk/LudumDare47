using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    [SerializeField] float max = 100;
    [SerializeField] float standbyDepletion = 1;
    private Slider fuelSlider;
    private bool shipTurnedOff = false;

    private void Awake()
    {
        GameManager.currentFuel = max;
        fuelSlider = GameObject.FindGameObjectWithTag("fuelBar").transform.GetComponent<Slider>();
    }

    void Update()
    {
        GameManager.currentFuel -= standbyDepletion * Time.deltaTime;
        updateSlider();

        if (!shipTurnedOff && GameManager.currentFuel < 0)
        {
            shipTurnedOff = true;
            GetComponent<ShipController>().gas.Disable();
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else if (GameManager.currentFuel < 0)
        {
            FuelIsEmpty();
        }
    }

    public void DepleteFuel(float amount)
    {
        GameManager.currentFuel -= amount;
    }

    private void updateSlider()
    {
        fuelSlider.value = GameManager.currentFuel / max;
    }

    private void FuelIsEmpty()
    {
        GameManager.PlayerCrash();
    }
}
