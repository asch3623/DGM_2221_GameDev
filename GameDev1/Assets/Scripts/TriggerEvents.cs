using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    public UnityEvent onEnter, onPlayerEnter, onPlayerExit, onProjectileEnter, onExit;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onPlayerEnter.Invoke();
        }
        else if (other.gameObject.CompareTag("Projectile"))
        {
             onProjectileEnter.Invoke(); 
        }
        else
        {
            onEnter.Invoke();
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onPlayerExit.Invoke();
        }
        else
        {
            onExit.Invoke(); 
        }
    }
}
