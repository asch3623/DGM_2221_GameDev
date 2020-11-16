using UnityEngine;
using UnityEngine.Events;

public class AlpacaBehavior : MonoBehaviour
{
    public UnityEvent[] Event;
    private int i;
    

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
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
