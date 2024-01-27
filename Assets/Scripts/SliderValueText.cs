using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class SliderValueText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sliderText = null;
    [SerializeField] private float maxSliderAmount = 1.0f;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_InputField input;

    private float inputValue;

    public string dataType;

    public void Update()
    {
        inputValue = Convert.ToInt32(input.text);
        slider.value = inputValue;
    }

    public void SliderChange(float value)
    {
        float localValue = value * maxSliderAmount;
        sliderText.text = localValue.ToString("F2") + dataType;
    }

}
