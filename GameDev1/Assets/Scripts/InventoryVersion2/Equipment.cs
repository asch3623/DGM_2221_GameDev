using System;
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

    public void UpgradeAttack(int amount)
    {
        attackDamage *= amount;
    }

    public void ChangeDescription(string message)
    {
        description = message;
    }

    public void SetAttackValue(int amount)
    {
        attackDamage = amount;
    }
}
