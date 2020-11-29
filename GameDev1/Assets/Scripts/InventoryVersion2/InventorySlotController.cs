using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
    public ItemObj item;

    private void Start()
    {
        updateInfo();
    }

    public void Use()
    {
        if (item)
        {
            item.Use();
            item.amount--;
            
            if (item.amount == 0)
            {
                InventorySystem.instance.Remove(item);
            }
            updateInfo();
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
