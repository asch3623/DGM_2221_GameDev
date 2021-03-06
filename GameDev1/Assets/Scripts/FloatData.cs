﻿using System.Collections;
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
    public UnityEvent lessThanZeroEvent, updateValueEvent, equalValueEvent;
    private bool isComplete;

    public void UpdateValue(float num)
    {
        value += num;
        updateValueEvent.Invoke();
    }

    public void SetValue(float num)
    {
        value = num;
    }

    public void SetMaxValue(float num)
    {
        maxValue = num;
    }

    public void MaxValueAbleToUpgrade()
    {
        isComplete = false;
    }
    
    public void SetValuetotheMaxValue()
    {
        value = maxValue;
        equalValueEvent.Invoke();
    }
    public void UpdateMaxValue(float num)
    {
        if (isComplete == false)
        {
            maxValue += num;
            isComplete = true;
        }
        
        
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
