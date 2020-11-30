using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class EnemyUIBehaviour : MonoBehaviour
{
    public EnemyBehaviour enemy;
    private float enemyHealth, enemyHealthMax;
    private Image healthUi;
    public Gradient gradient;
    public UnityEvent lessThanZeroEvent;
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
        enemyHealth = enemy.enemyHealth;
        enemyHealthMax = enemy.enemyHealthMax;
        
        if (enemyHealth > 0 || enemyHealth <= enemyHealthMax)
        {
            healthUi.fillAmount = enemyHealth / enemyHealthMax;
        }

        if (enemyHealth <= 0)
        {
            lessThanZeroEvent.Invoke();
        }

        if (enemyHealth >= enemyHealthMax)
        {
            enemyHealth = enemyHealthMax;
        }
        healthUi.color = gradient.Evaluate(healthUi.fillAmount);

    }
}

