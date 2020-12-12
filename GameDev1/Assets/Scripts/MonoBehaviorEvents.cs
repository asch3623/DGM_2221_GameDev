using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoBehaviorEvents : MonoBehaviour
{
    public UnityEvent startEvent, onEnableEvent;
    void Start()
    {
        startEvent?.Invoke();
    }

    private void OnEnable()
    {
        onEnableEvent.Invoke();
    }
    
}
