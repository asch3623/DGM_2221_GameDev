using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu (fileName = "new Consumable", menuName = "Items/Equipment")]
public class Equipment : ItemObj
{
    public UnityEvent useEvent;
    public int defense;
    public int attackDamage;
    public override void Use()
    {
        useEvent.Invoke();

    }
}
