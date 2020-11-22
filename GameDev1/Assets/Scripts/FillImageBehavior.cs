using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FillImageBehavior : MonoBehaviour
{
  private Image im;
  public BoolData coolDown, isDart;
  private float fillValue = 1f;
  private float maxFill = 1.1f, minFill = -0.1f;

  private float seconds = .5f;
 
    void Start()
    {

        im = GetComponent<Image>();
        im.fillAmount = fillValue;
        isDart.value = false;
    }

    void Update()
    {
        if (isDart.value)
        {
            StartCoroutine(decreaseFillVal());
      
            im.fillAmount = fillValue;
            return;
        }
        if (coolDown.value && !isDart.value)
        {
            
           StartCoroutine(increaseFillVal());
           im.fillAmount = fillValue;
        }
    }

    IEnumerator decreaseFillVal()
    {
        while (isDart.value && fillValue >= minFill)
                    {
                        fillValue -= 0.1f;
                        im.fillAmount = fillValue;
                        yield return new WaitForSeconds(seconds);
                    }
    }
    IEnumerator increaseFillVal()
    {
        while (coolDown.value && fillValue <= maxFill)
        {
            yield return new WaitForSeconds(1);
            fillValue += 0.001f;
            im.fillAmount = fillValue;
            
        }
    }
}
