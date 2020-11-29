using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemObj item;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            
            InventorySystem.instance.Add(item);
            Destroy(this);
            
        }
    }
}
