using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    [SerializeField] float max = 100;
    [SerializeField] float standbyDepletion = 1;
    private float current;
    private Slider fuelSlider;
    private bool shipTurnedOff = false;

    private void Awake()
    {
        current = max;
        fuelSlider = GameObject.FindGameObjectWithTag("fuelBar").transform.GetComponent<Slider>();
    }

    void Update()
    {
        current -= standbyDepletion * Time.deltaTime;
        updateSlider();

        if (!shipTurnedOff && current < 0)
        {
            shipTurnedOff = true;
            GetComponent<ShipController>().gas.Disable();
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void DepleteFuel(float amount)
    {
        current -= amount;
    }

    private void updateSlider()
    {
        fuelSlider.value = current / max;
    }
}
