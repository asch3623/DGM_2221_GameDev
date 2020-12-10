using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    private Text t;
    public FloatData health;
    void Start()
    {
        t = GetComponent<Text>();
        t.text = health.value + " / " + health.maxValue;
    }
    public void UpdateText()
    {
        t.text = health.value + " / " + health.maxValue;
    }
}
