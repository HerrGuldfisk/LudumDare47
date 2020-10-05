using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    [SerializeField] float standbyDepletion = 1;
    private Slider fuelSlider;
    private Text screenText;
    public bool fuelEmpty = false;

    private void Awake()
    {
        GameManager.currentFuel = GameManager.maxFuel;
        fuelSlider = GameObject.FindGameObjectWithTag("fuelBar").transform.GetComponent<Slider>();
        screenText = GameObject.FindGameObjectWithTag("ScreenMessage").GetComponent<Text>();
    }

    void Update()
    {
        /*
        if (GameManager.inOrbit)
        {
            GameManager.currentFuel -= standbyDepletion * Time.deltaTime;
        }
        */
        
        updateSlider();

        if (GameManager.currentFuel < 0)
        {
            GameManager.currentFuel = 0;
        }

        if (!fuelEmpty && GameManager.currentFuel == 0)
        {
            FuelIsEmpty();
        }
    }

    public void DepleteFuel(float amount)
    {
        GameManager.currentFuel -= amount;
    }

    public void addFuel(float amount)
    {
        GameManager.currentFuel += amount;
        GameManager.currentFuel = Mathf.Clamp(GameManager.currentFuel, 0, GameManager.maxFuel);
        fuelEmpty = false;
        screenText.enabled = false;
    }

    private void updateSlider()
    {
        fuelSlider.value = GameManager.currentFuel / GameManager.maxFuel;
    }

    private void FuelIsEmpty()
    {
        fuelEmpty = true;

        screenText.enabled = true;
        screenText.text = "Out of fuel";
        screenText.color = Color.red;
    }
}
