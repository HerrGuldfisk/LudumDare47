using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetResources : MonoBehaviour
{
    [SerializeField] int max = 20;
    [SerializeField] float spawnInterval = 0.2f;
    [SerializeField] GameObject resource;
    private int current;
    private bool isSpawning;
    private float timer = 0;
    private shipResources shipResources;
    private Slider slider;
    private Text text;


    private void Awake()
    {
        current = Random.Range(2,max);
        isSpawning = false;
        slider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<Text>();
        updateSlider();
    }

    private void updateSlider()
    {
        if (slider)
        {
            slider.value = (float)current / (float)max;
            text.text = current.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship"))
        {
            shipResources = collision.gameObject.GetComponent<shipResources>();
            if (current > 0 && !shipResources.full)
            {
                isSpawning = true;
                collision.GetComponent<ShipController>().PlaySuckSound();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship"))
        {
            isSpawning = false;
            collision.GetComponent<ShipController>().StopSuckSound();
        }
    }

    void Update()
    {
        if (isSpawning)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                GameObject spawned = Object.Instantiate(resource, transform.position, transform.rotation);
                spawned.GetComponent<Resource>().target = shipResources.transform;
                timer = spawnInterval;
                current--;
                updateSlider();
            }

            if (current < 1)
            {
                isSpawning = false;
                slider.gameObject.SetActive(false);
            }

            if (shipResources.full)
            {
                isSpawning = false;
            }
        }
    }
}
