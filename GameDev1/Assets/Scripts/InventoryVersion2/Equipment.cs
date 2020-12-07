using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu (fileName = "new Consumable", menuName = "Items/Equipment")]
public class Equipment : ItemObj
{
    private void Awake()
    {
        type = ItemType.Equipment;
    }

    public UnityEvent useEvent;
    public int defense;
    public int attackDamage;
    public override void Use()
    {
        useEvent.Invoke();

    }
}
