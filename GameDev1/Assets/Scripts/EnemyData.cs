using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public IntData playerAttackDamage;
    public FloatData enemyHealth;
    public UnityEvent lessThanZeroEvent, updateValueEvent;

    public void PlayerAttackEnemy()
    {
        enemyHealth.value += playerAttackDamage.value;
        updateValueEvent.Invoke();
    }
    
    public void SetValuetotheMaxValue()
    {
        enemyHealth.value = enemyHealth.maxValue;
    }
    
    public void SetImageFillAmount(Image img)
    {
        
        if (enemyHealth.value > 0 || enemyHealth.value <= enemyHealth.maxValue)
        {
            img.fillAmount = enemyHealth.value/enemyHealth.maxValue;
        }

        if (enemyHealth.value <= 0)
        {
            lessThanZeroEvent.Invoke();
        }

        if (enemyHealth.value >= enemyHealth.maxValue)
        {
            enemyHealth.value = enemyHealth.maxValue;
        }
    }
}
