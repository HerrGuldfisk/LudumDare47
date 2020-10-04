using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shipResources : MonoBehaviour
{
    private Slider slider;
    [SerializeField] int max = 15;
    private int current = 0;
    public bool full;
    public bool empty;

    private void Awake()
    {
        slider= GameObject.FindGameObjectWithTag("ResourceBar").transform.GetComponent<Slider>();
        updateSlider();
        checkFull();
    }

    private void checkFull()
    {
        if (current >= max)
        {
            full = true;
            empty = false;
        }
        else if (current < 1)
        {
            full = false;
            empty = true;
        }
        else
        {
            full = false;
            empty = false;
        }
    }

    public void addResource()
    {
        if (!full)
        {
            current++;
            updateSlider();
            checkFull();
        }
    }

    public void removeResource()
    {
        if (!empty)
        {
            current--;
            updateSlider();
            checkFull();
        }
    }

    private void updateSlider()
    {
        if (slider)
        {
            slider.value = (float)current / (float)max;
        }
    }
}
