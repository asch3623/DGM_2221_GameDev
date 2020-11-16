using System;
using UnityEngine;
using UnityEngine.Events;

public class AlpacaBehavior : MonoBehaviour
{
    public UnityEvent Event;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("e"))
        {
            Event.Invoke();
        }
    }
}
