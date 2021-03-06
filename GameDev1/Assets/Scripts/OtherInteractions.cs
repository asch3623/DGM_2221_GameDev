﻿using UnityEngine;
using UnityEngine.Events;

public class OtherInteractions : MonoBehaviour
{
   public UnityEvent onInteraction;
   private bool isInRange, interactKey;

   private void Update()
   {
      interactKey = Input.GetKeyDown(KeyCode.E);
      if (interactKey && isInRange)
      {
         onInteraction.Invoke();
      }
   }
   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         isInRange = true;
      }
      

   }
   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "Player")
      {
         isInRange = false; 
      }
  

   }
}
