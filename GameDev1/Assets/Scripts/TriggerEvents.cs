using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    public UnityEvent onEnter, onExit;
    
    private void OnTriggerEnter(Collider other)
    {
        onEnter.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        onExit.Invoke();
    }
}
