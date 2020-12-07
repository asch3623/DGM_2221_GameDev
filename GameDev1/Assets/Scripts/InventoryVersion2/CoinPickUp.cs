using System.Net.Mime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CoinPickUp : MonoBehaviour
{
   public IntData coinAmount;
   public int coinValue;
   public UnityEvent coinPickUpEvent;
   public GameObject textUi;
   private Text t;
   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
        coinAmount.value += coinValue;
        coinPickUpEvent.Invoke();
        CreateText();
        Destroy(gameObject); 
      }
      
   }
   
   
   public void CreateText()
   {
       t = textUi.GetComponent<Text>();
       t.text = "Added: <color=#00ff00ff>" + coinValue + " coins!</color>";
       Instantiate(textUi, UIReference.instance.transform);
   }
   
}
