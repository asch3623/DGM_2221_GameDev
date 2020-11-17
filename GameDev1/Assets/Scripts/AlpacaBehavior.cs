using System;
using UnityEngine;
using UnityEngine.Events;

public class AlpacaBehavior : MonoBehaviour
{
    public UnityEvent[] Event;
    private int i;
    private bool canPickUp;

    private void Update()
    {
        canPickUp = Input.GetKey(KeyCode.E);
    }

    private void OnTriggerStay(Collider other)
    {
        if (canPickUp)
        {
            if (Event.Length > 1 && i < Event.Length - 1)
            {
                Event[i].Invoke();
                print("invoked");
                i++;
            }
            else
            {
                if (Event[i] != null)
                {
                    Event[i].Invoke();
                }
                else
                {
                    i = Event.Length -1;
                }
                
                
            }
        }
        
    }
    
}
