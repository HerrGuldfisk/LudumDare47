using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    [SerializeField] float standbyDepletion = 1;
    [SerializeField] float maxFuel;

    private Slider fuelSlider;
    private Text screenText;
    [HideInInspector] public bool fuelEmpty = false;

    //fuel warning system
    [SerializeField] Image fuelBorder;
    [SerializeField] Text fuelWarningText;
    [SerializeField] float fuelWarningFreq = 0.5f;
    private float fuelWarningTimer;
    private bool fuelLow = false;

    private void Awake()
    {
        GameManager.maxFuel = maxFuel;
        GameManager.currentFuel = maxFuel;
        fuelSlider = GameObject.FindGameObjectWithTag("fuelBar").transform.GetComponent<Slider>();
        screenText = GameObject.FindGameObjectWithTag("ScreenMessage").GetComponent<Text>();
        fuelWarningText.enabled = false;
        fuelWarningTimer = fuelWarningFreq;
    }

    void Update()
    {   
        if (GameManager.currentFuel < 0)
        {
            GameManager.currentFuel = 0;
        }

        if (!fuelEmpty && GameManager.currentFuel == 0)
        {
            FuelIsEmpty();
        }

        if (fuelLow)
        {
            fuelWarningTimer -= Time.deltaTime;
            if (fuelWarningTimer < 0)
            {
                fuelWarningTimer = fuelWarningFreq;
                fuelWarningText.enabled = !fuelWarningText.enabled;
            }
        }
    }

    public void DepleteFuel(float amount)
    {
        GameManager.currentFuel -= amount;
        updateSlider();

        if (!fuelLow && GameManager.currentFuel / GameManager.maxFuel < 0.2f)
        {
            fuelLow = true;
            fuelBorder.color = Color.red;
            fuelWarningText.enabled = true;
        }
    }

    public void addFuel(float amount)
    {
        GameManager.currentFuel += amount;
        GameManager.currentFuel = Mathf.Clamp(GameManager.currentFuel, 0, GameManager.maxFuel);
        fuelEmpty = false;
        screenText.enabled = false;
        updateSlider();

        if (fuelLow && GameManager.currentFuel / GameManager.maxFuel > 0.2f)
        {
            fuelLow = false;
            fuelBorder.color = Color.black;
            fuelWarningText.enabled = false;
        }
    }

    private void updateSlider()
    {
        fuelSlider.value = GameManager.currentFuel / GameManager.maxFuel;
    }

    private void FuelIsEmpty()
    {
        fuelEmpty = true;
    }
}
