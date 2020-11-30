using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class InstanceWeapon : MonoBehaviour
{
    public GameObject weapon;
    public UnityEvent turnOnUI, turnOffUi;
    private ItemObj item;
    private InstanceWeapon _instanceWeapon;
    private Vector3 zero;
   

    private void Start()
    {
        _instanceWeapon = gameObject.GetComponent<InstanceWeapon>();
       


    }

    public void Equip()
    {
       var newWeapon = Instantiate(weapon, zero, Quaternion.identity);
       newWeapon.transform.parent = gameObject.transform;
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
        Destroy(gameObject.transform.GetChild(0).gameObject);
        _instanceWeapon.enabled = false;
    }
}
