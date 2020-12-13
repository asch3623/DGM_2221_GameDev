using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
   public int costAmount;
   public ItemObj itemToBuy;
   public IntData playerCoins;
   public UnityEvent buyEvent, cannotBuyEvent;

   public void Buy()
   {
      if (playerCoins.value >= costAmount)
      {
         InventorySystem.instance.Add(itemToBuy);
         playerCoins.value -= costAmount;
         buyEvent.Invoke();
      }
      else
      {
         cannotBuyEvent.Invoke();
      }
   }

}
