using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shipResources : MonoBehaviour
{
    private Slider slider;
    private int max = 15;
    private int current = 0;

    private void Awake()
    {
        slider= GameObject.FindGameObjectWithTag("ResourceBar").transform.GetComponent<Slider>();
        updateSlider();
    }

    public void addResource()
    {
        current++;
        updateSlider();
    }

    private void updateSlider()
    {
        if (slider)
        {
            slider.value = (float)current / (float)max;
        }
    }
}
