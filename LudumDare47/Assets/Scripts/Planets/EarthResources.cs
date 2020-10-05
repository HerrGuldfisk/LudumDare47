using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarthResources : MonoBehaviour
{
    [SerializeField] int max = 50;
    [SerializeField] float spawnInterval = 0.2f;
    [SerializeField] GameObject resource;
    [SerializeField] Transform planet;
	private int current;
    private bool isSpawning;
    private float timer = 0;
    private shipResources shipResources;
    private Slider slider;
    private Text text;
    private GameObject crashmenu;
    private CanvasGroup canvasGroup;


    private void Awake()
    {
        current = 0;
        isSpawning = false;
        slider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<Text>();

        crashmenu = GameObject.FindGameObjectWithTag("CrashMenu");
        canvasGroup = crashmenu.GetComponent<CanvasGroup>();

        updateSlider();
    }

    private void updateSlider()
    {
        if (slider)
        {
            slider.value = (float)current / (float)max;
            text.text = current.ToString() + "/" + max.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship"))
        {
            shipResources = collision.gameObject.GetComponent<shipResources>();
            if (!shipResources.empty)
            {
                isSpawning = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship"))
        {
            isSpawning = false;
        }
    }

    void Update()
    {
        if (isSpawning)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                spawn();
                timer = spawnInterval;
            }

            if (shipResources.empty)
            {
                isSpawning = false;
            }
        }
    }

    private void spawn()
    {
        GameObject spawnedResource = Object.Instantiate(resource, shipResources.transform.position, transform.rotation);
        spawnedResource.GetComponent<MoveTowardsTagged>().startMoving(planet);
        spawnedResource.GetComponent<Resource>().target = planet;

        shipResources.removeResource();
    }

    public void addResource()
    {
        current++;
        updateSlider();
        if (current >= max)
        {
            win();
        }
    }

    private void win()
    {
        canvasGroup.alpha = 1;
        crashmenu.GetComponentInChildren<Text>().text = "THE EARTH WAS SAVED!!!";
        shipResources.gameObject.SetActive(false);
    }
}
