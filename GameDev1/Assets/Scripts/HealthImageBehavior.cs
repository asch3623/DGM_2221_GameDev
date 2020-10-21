using UnityEngine;
using Image = UnityEngine.UI.Image;
[RequireComponent(typeof(Image))]
public class HealthImageBehavior : MonoBehaviour
{
    public FloatData health;
    private Image healthUi;
    private Color imageColor;
    private Color green, yellow, red;
    void Start()
    {
        healthUi = GetComponent<Image>();
        green = Color.green;
        yellow = Color.yellow;
        red = Color.red;
    }
    
    void Update()
    {
        healthUi.fillAmount = health.value;
        health.value = Mathf.Clamp(health.value, -0.1f, 1.1f);
        if (health.value >= 1f)
        {
            healthUi.color = green;
        }
        if (health.value <= .6f)
        {
            healthUi.color = yellow;
        }
        if (health.value <= .3f)
        {
            healthUi.color = red;
        }
    }
}
