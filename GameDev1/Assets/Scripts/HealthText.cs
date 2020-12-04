using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    private Text t;
    public FloatData health, maxHealth;
    void Start()
    {
        t = GetComponent<Text>();
        t.text = health.value + " / " + maxHealth.value;
    }
    void UpdateText()
    {
        t.text = health.value + " / " + maxHealth.value;
    }
}
