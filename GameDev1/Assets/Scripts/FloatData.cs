using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float value;

    public void ChangeValue(float num)
    {
        value += num;
    }
    
}
