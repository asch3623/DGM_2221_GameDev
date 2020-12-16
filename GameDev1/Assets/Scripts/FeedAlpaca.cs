using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FeedAlpaca : MonoBehaviour
{
    private Text t;
    public GameObject textUi;
    public IntData alpacaLove;
    public BoolData isEquipped;
    private bool isAwarded;
    public UnityEvent gaveItem, giveBadge;
    public BadgeObj badge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Alpaca")
        {
            alpacaLove.value += 1;
            if (alpacaLove.value > 5)
            {
                alpacaLove.value = 5;
            }
            CreateText();
            isEquipped.value = false;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Greg")
        {
            gaveItem.Invoke();
            giveBadge.Invoke();
            isEquipped.value = false;
            Destroy(gameObject);
        }
    }
    
    public void CreateText()
    {
        t = textUi.GetComponent<Text>();
         if (alpacaLove.value < 5)
         { 
             t.text = "++Alpacas love hay! Alpaca love stat increased!";
         } 
        else if (alpacaLove.value == 5 && isAwarded == false)
        {
            t.text = "<color=#FF0000> You won the award: BEST ALPACA HERDER! </color>";
            badge.isObtained = true;
            giveBadge.Invoke();
            isAwarded = true;
        }
      
        else
        {
            t.text = "Alpaca love stat MAXED";
        }
        
        Instantiate(textUi, UIReference.instance.transform);
    }
}
