using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class InstanceWeapon : MonoBehaviour
{
    public GameObject weapon;
    public UnityEvent turnOnUI, turnOffUi, unequipEvent;
    private ItemObj item;
    private InstanceWeapon _instanceWeapon;
    private Vector3 zero;


    private void Start()
    {
        _instanceWeapon = gameObject.GetComponent<InstanceWeapon>();


    }

    public void Equip()
    {
       var newWeapon = Instantiate(weapon, weapon.transform.position, weapon.transform.rotation);
       
       newWeapon.transform.parent = gameObject.transform.parent;

       turnOnUI.Invoke();
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
        turnOffUi.Invoke();
        item = weapon.GetComponent<WeaponBehavior>().weapon;
        InventorySystem.instance.Add(item);
        FindWeapon();
        unequipEvent.Invoke();
        _instanceWeapon.enabled = false;
    }

    private void FindWeapon()
    {
        foreach (Transform child in gameObject.transform.parent.transform)
        {
            if (child.GetComponent<WeaponBehavior>())
            {
                Destroy(child.gameObject);
            }
        }
    }
}
