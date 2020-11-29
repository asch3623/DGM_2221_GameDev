using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float maxValue;
    public float value;
    public UnityEvent lessThanZeroEvent, updateValueEvent;

    public void UpdateValue(float num)
    {
        value += num;
        updateValueEvent.Invoke();
    }
    
    public void SetValuetotheMaxValue()
    {
        value = maxValue;
    }
    
    public void SetImageFillAmount(Image img)
    {
        if (value > 0 || value <= maxValue)
        {
            img.fillAmount = value/maxValue;
        }

        if (value <= 0)
        {
            lessThanZeroEvent.Invoke();
        }

        if (value >= maxValue)
        {
            value = maxValue;
        }
    }

}
