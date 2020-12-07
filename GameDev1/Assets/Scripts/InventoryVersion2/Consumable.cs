using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu (fileName = "new Consumable", menuName = "Items/Consumable")]
public class Consumable : ItemObj
{
    public UnityEvent updateHealth;
    
    private void Awake()
    {
        type = ItemType.Consumable;
    }
    public override void Use()
    {
        updateHealth.Invoke();

    }

    // public void Heal(float amount)
    // {
    //     playerHealth.value += amount;
    //     if (playerHealth.value > playerHealth.maxValue)
    //     {
    //         playerHealth.value = playerHealth.maxValue;
    //     }
    //     updateHealth.Invoke();
    // }
}
