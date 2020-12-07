using UnityEngine;
using UnityEngine.Events;

public class InteractBehavior : MonoBehaviour
{
    public UnityEvent Event;
    private int i;
    private bool canPickUp, isOpen, isInRange, hasAllAlpacas;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isOpen", true);
    }

    private void Update()
    {
        canPickUp = Input.GetKeyDown(KeyCode.E);
        if (canPickUp && isInRange)
        {
         CheckIfOpenOrClosed();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;

    }
    private void OnTriggerExit(Collider other)
    {
        isInRange = false;

    }

    public void CloseGateMission()
    {
        hasAllAlpacas = true;
    }

    public void CheckIfOpenOrClosed()
    {
        if (anim.GetBool("isOpen"))
        {
                anim.SetBool("isOpen", false);
                if (hasAllAlpacas)
                {
                    isInRange = false;
                    Event.Invoke();
                }
        }
            else
        {
                anim.SetBool("isOpen", true);
                
        }

    }
    
}
