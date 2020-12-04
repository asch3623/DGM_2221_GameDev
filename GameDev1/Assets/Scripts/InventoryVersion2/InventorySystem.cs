using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
   public List<ItemObj> list = new List<ItemObj>();
   public List<ItemObj> allItems;
   public static InventorySystem instance;
   public GameObject slots;

   private void Start()
   {
      instance = this;
      GetItems();
   }

   public void GetItems()
   {
      int a = 0;
      foreach (ItemObj item in allItems)
      {
         var value = item.amount;
         if (value > 0)
         {
            list.Add(item);
            updatePanelSlots();
         }
         a++;
      }
   }
   

   public void updatePanelSlots()
   {
      int i = 0;
      foreach (Transform child in slots.transform)
      {
         InventorySlotController slot = child.GetComponent<InventorySlotController>();

         if (i < list.Count)
         {
            slot.item = list[i];
         }
         else
         {
            slot.item = null;
         }
         slot.updateInfo();
         i++;
      }
   }

   public virtual void Add(ItemObj item)
   {
     
      if (item.amount >= 1)
      {
         Debug.Log("Added an item to the Count");
         item.amount++;
         updatePanelSlots();
      }
      else
      if (list.Count < 9)
      {
         Debug.Log("Added a new item");
         list.Add(item);
         item.amount++;
         updatePanelSlots();
      }
      else
      {
         Debug.Log("List is full");
      }
   }
   public void Remove(ItemObj item)
   {
      list.Remove(item);
      updatePanelSlots();
   }
}
