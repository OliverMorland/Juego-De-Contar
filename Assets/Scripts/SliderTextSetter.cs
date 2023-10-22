using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderTextSetter : MonoBehaviour
{
    [SerializeField] TMP_Text label;

    public void SetSliderValue(float sliderValue)
    {
        int sliderValueAsInt = (int)sliderValue;
        label.text = $"{sliderValueAsInt}";
    }
}
