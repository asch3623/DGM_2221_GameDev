using UnityEngine;
using Image = UnityEngine.UI.Image;
[RequireComponent(typeof(Image))]
public class HealthImageBehavior : MonoBehaviour
{
    public FloatData health;
    private Image healthUi;
    public Gradient gradient;
    void Awake()
    {
        healthUi = GetComponent<Image>();
        healthUi.fillAmount = health.value/health.maxValue;
        healthUi.color = gradient.Evaluate(healthUi.fillAmount);

    }
    
   public void UpdateValue()
    {
        healthUi.fillAmount = health.value/health.maxValue;
        healthUi.color = gradient.Evaluate(healthUi.fillAmount);

    }
}
