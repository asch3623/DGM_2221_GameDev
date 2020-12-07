using UnityEngine;
using UnityEngine.Events;

public class InstanceWeapon : MonoBehaviour
{
    private GameObject thisWeapon;
    public UnityEvent turnOnUI, turnOffUi, unequipEvent;
    private ItemObj item;
    private InstanceWeapon _instanceWeapon;
    private Vector3 zero;
    public BoolData isAlreadyEquipped;


    private void Start()
    {
        _instanceWeapon = gameObject.GetComponent<InstanceWeapon>();


    }

    public void Equip(GameObject weapon)
    {
        if (isAlreadyEquipped.value == false)
        {
            thisWeapon = weapon;
            var newWeapon = Instantiate(weapon, weapon.transform.position, weapon.transform.rotation);
                   
            newWeapon.transform.parent = gameObject.transform.parent;
            
            turnOnUI.Invoke();
            isAlreadyEquipped.value = true;
        }
        else
        {
            print("Item already equipped.");
        }
       
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
        item = thisWeapon.GetComponent<ItemInfo>().item;
        InventorySystem.instance.Add(item);
        FindWeapon();
        unequipEvent.Invoke();
        isAlreadyEquipped.value = false;
        _instanceWeapon.enabled = false;
    }

    private void FindWeapon()
    {
        foreach (Transform child in gameObject.transform.parent.transform)
        {
            if (child.GetComponent<ItemInfo>() != null)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
