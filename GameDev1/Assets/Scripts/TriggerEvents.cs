using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    public UnityEvent onEnter;
    
    private void OnTriggerEnter(Collider other)
    {
        onEnter.Invoke();
    }
}
