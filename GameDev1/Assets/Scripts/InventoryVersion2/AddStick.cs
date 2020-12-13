using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStick : MonoBehaviour
{
    public ItemObj item;
    void Start()
    {
        if (item.amount == 0)
        {
           InventorySystem.instance.Add(item);  
        }
       
    }

}
