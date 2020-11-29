using System;
using UnityEngine;
using UnityEngine.UI;

public class InstanceWeapon : MonoBehaviour
{
    public GameObject weapon;
    private ItemObj item;
    private InstanceWeapon _instanceWeapon;


    private void Start()
    {
        _instanceWeapon = gameObject.GetComponent<InstanceWeapon>();
    }

    public void Equip()
    {
       var newWeapon = Instantiate(weapon, gameObject.transform.position, gameObject.transform.rotation);
       newWeapon.transform.parent = gameObject.transform;
    }

    public void Update()
    {
        if (enabled && Input.GetKeyDown(KeyCode.Q))
        {
            UnEquip();
        }
    }

    public void UnEquip()
    {
        item = weapon.GetComponent<WeaponBehavior>().weapon;
        InventorySystem.instance.Add(item);
        Destroy(gameObject.transform.GetChild(0).gameObject);
        _instanceWeapon.enabled = false;
    }
}
