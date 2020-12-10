using UnityEngine;
using UnityEngine.UI;

public class onMouseOver : MonoBehaviour
{
    public GameObject description;
    private Text t;
    private InventorySlotController slot;

    private void Start()
    {
        t = description.transform.GetComponentInChildren<Text>();
        slot = GetComponent<InventorySlotController>();
    }
    

    public void OnMouseExit()
    {
        description.gameObject.SetActive(false);
    }

    public void ItemDisplayDescription()
    {
        if (slot.item)
        {
            description.SetActive(true);
           var x = Input.mousePosition.x + 2 ;
            var y = Input.mousePosition.y + 2;
            description.transform.position =
                new Vector3(x, description.transform.position.y, description.transform.position.z);
            t.text = slot.item.description;
        }
    }
}
