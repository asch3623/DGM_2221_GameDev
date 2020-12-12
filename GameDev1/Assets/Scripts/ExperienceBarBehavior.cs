using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExperienceBarBehavior : MonoBehaviour
{
   public FloatData experience;
   private Image im;
   public float multiplier = .5f;
   public UnityEvent levelUpEvent;
   private CreateText textToPrint;
   public IntData levelCount;
   public Text count;

   private void Awake()
   {
      im = GetComponent<Image>();
      textToPrint = GetComponent<CreateText>();
   }

   public void UpdateImageFill()
   {
      im.fillAmount = experience.value / experience.maxValue;
      count.text = "Level " + levelCount.value + "\n " + experience.value + "/" + experience.maxValue;
      if (experience.value >= experience.maxValue)
      {
         levelCount.value++;
         levelUpEvent.Invoke();
         if (levelCount.value == 3)
         {
            textToPrint.PrintText("Reached Level 3: Max Health Increased!");
         }
         if (levelCount.value == 4)
         {
            textToPrint.PrintText("Reached Level 4: Max Health Increased!");
         }
         if (levelCount.value == 5)
         {
            textToPrint.PrintText("Reached Level 5: Max Health Increased!");
         }
         experience.value = 0;
         experience.maxValue += experience.maxValue + (experience.maxValue * multiplier);
         experience.maxValue = Mathf.Round(experience.maxValue);
         im.fillAmount = experience.value / experience.maxValue;
         count.text = "Level " + levelCount.value + "\n " + experience.value + "/" + experience.maxValue;
      }
   }
   
}
