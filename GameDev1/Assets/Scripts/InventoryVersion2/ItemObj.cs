using System;
using UnityEngine;

public class ItemObj : ScriptableObject
{
  public enum ItemType
  {
    Equipment,
    Consumable
  }


  public ItemType type;
  public string itemName;
  public Sprite icon;
  public int amount;
  [TextArea (10,15)]
  public string description;
  

  public virtual void Use()
  {
    
  }
}
