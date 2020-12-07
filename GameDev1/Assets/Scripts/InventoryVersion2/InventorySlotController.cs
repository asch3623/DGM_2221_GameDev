using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
    public ItemObj item;
    public BoolData isEquipped;
    public GameObject pickUpBox;
    private Text t, instanceT;
    public bool thisItemIsClicked;
    public GameObject textUi;

    private void Start()
    {
        isEquipped.value = false;
        updateInfo();
        t = pickUpBox.transform.Find("Text").GetComponent<Text>();
        thisItemIsClicked = false;
        instanceT = textUi.GetComponent<Text>();
    }

    public void ChangeBool(bool thisBool)
    {
        thisItemIsClicked = thisBool;
    }

    public void Use()
    {
        if (item)
        {
            if (isEquipped.value == false || item.type == ItemObj.ItemType.Consumable)
            {
                pickUpBox.SetActive(true);
                thisItemIsClicked = true;
                t.text = "Do you want to use <color=#006D5B> " + item.name + " </color>?";
            }
            else
            {
                instanceT.text = "You cannot hold two items at once! Press Q while holding an item to unEquip it.";
                Instantiate(textUi, UIReference.instance.transform);
            }
            
        }
    }

    public void WantstoUseItem()
    {
        if (thisItemIsClicked)
        {
            Debug.Log("is not equipped");
             item.Use();
             item.amount--;
             
             if (item.amount == 0)
             {
                 InventorySystem.instance.Remove(item);
             }
             updateInfo();
             pickUpBox.SetActive(false);
             thisItemIsClicked = false;
        }
       
    }

    public void DropItem()
    { 
        if (thisItemIsClicked)
        {
            item.amount--;
                                        
            if (item.amount == 0)
            {
                InventorySystem.instance.Remove(item);
            }
            updateInfo();
            pickUpBox.SetActive(false);
            thisItemIsClicked = false;
        }
        
    }
    
    
    public void updateInfo()
    {
        Text displayText = transform.Find("Text").GetComponent<Text>();
        Text displayAmount = transform.Find("Amount").GetComponent<Text>();
        Image displayImage = transform.Find("Icon").GetComponent<Image>();
        displayImage.color = Color.clear;

        if (item)
        {
            displayImage.color = Color.white;
            displayImage.sprite = item.icon;
            displayText.text = item.name;
            if (item.amount > 1)
            {
              displayAmount.text = item.amount.ToString();  
            }
            else
            {
                displayAmount.text = "";
            }
            
        }
        else
        {
            displayImage.sprite = null;
            displayText.text = "";
            displayAmount.text = "";
            displayImage.color = Color.clear;
        }
    }
}
