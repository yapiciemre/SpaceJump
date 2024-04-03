using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1.0f;
    }

    public void SliderValue(int maxSliderValue, int maxCurrentValue)
    {
        int sliderValue = maxSliderValue - maxCurrentValue;
        slider.maxValue = maxSliderValue;
        slider.value = sliderValue;
    }
}
