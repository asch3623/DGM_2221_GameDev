using UnityEngine;
using UnityEngine.UI;

public class ImageColorBehavior : MonoBehaviour
{
   private Image thisImage;
   public Color newColor, oldColor;

   private void Start()
   {
      thisImage = GetComponent<Image>(); 
      thisImage.color = oldColor;
   }

   public void changeColor()
   {
      thisImage.color = newColor;
   }

   public void changeBackToOldColor()
   {
      thisImage.color = oldColor;
   }
}
