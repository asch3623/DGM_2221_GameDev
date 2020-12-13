using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int value;

    public void ChangeValue(int num)
    {
        value += num;
    }

    public void SetValue(int num)
    {
        value = num;
    }
}
