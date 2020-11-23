using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class EnemyUIBehaviour : MonoBehaviour
{
    public EnemyBehaviour enemy;
    private float enemyHealth, enemyHealthMax;
    private Image healthUi;
    public Gradient gradient;
    void Start()
    {
        enemyHealth = enemy.enemyHealth;

        enemyHealthMax = enemy.enemyHealthMax;
                
                
        healthUi = GetComponent<Image>();
        healthUi.fillAmount = enemyHealth/enemyHealthMax;
        healthUi.color = gradient.Evaluate(healthUi.fillAmount);
    }
    
    public void UpdateValue()
    {

        healthUi.color = gradient.Evaluate(healthUi.fillAmount);

    }
}

