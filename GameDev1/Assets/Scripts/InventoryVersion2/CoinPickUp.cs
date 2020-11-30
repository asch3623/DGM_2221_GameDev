using UnityEngine;
using UnityEngine.Events;

public class CoinPickUp : MonoBehaviour
{
   public IntData coinAmount;
   public int coinValue;
   public UnityEvent coinPickUpEvent;
   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
        coinAmount.value += coinValue;
        coinPickUpEvent.Invoke();
        Destroy(gameObject); 
      }
      
   }
}
