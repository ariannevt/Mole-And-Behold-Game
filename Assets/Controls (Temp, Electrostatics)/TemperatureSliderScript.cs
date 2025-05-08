using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TemperatureSliderScript : MonoBehaviour  //attached to the TemperatureSlider GameObject that is inactive until user checks the box
{
    public float SpeedValueFromTempSlider;
    public Slider TemperatureSlider;
    public TMP_Text TemperatureSliderDisplayValue;

    // Start is called before the first frame update
    void Start()
    {
        TemperatureSlider = GetComponent<Slider>();
        ChangeParticleSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeParticleSpeed()
    {
        if(TemperatureSlider.value == 0)
        {
            SpeedValueFromTempSlider = 0;
        }

        else
        {
            SpeedValueFromTempSlider = Mathf.Pow(2, TemperatureSlider.value);  //Powers of 2!    
        }

        TemperatureSliderDisplayValue.text = TemperatureSlider.value.ToString();

    }

}
