using System;
using UnityEngine;
using UnityEngine.Events;

public class CountChecker : MonoBehaviour
{
    public IntData maxCount, count;
    public UnityEvent Event;

    private void Start()
    {
        count.value = 0;
        maxCount.value = 5;
    }

    public void CheckMaxAlpacas()
    {
        if (count.value == maxCount.value)
        {
            Event.Invoke();
        }
    }
    
}
