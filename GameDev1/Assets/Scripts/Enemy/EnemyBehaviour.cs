using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;


[RequireComponent(typeof(TransparencyFade))]
public class EnemyBehaviour : MonoBehaviour
{
    public IntData playerAttackDamage;
    public float enemyHealth, enemyHealthMax;
    public UnityEvent lessThanZeroEvent, onPlayerAttackEvent, imgFillEvent;
    public bool isHit;
    private int seconds = 1;
    private TransparencyFade fade;
    private Vector3 pos;

    private void Start()
    {
        pos = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        fade = GetComponent<TransparencyFade>();
        isHit = false;
    }

    public void Initialize()
    {
        Instantiate(gameObject, pos, gameObject.transform.rotation);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Projectile"))
        {
            isHit = true;
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(seconds);
        isHit = false;
    }


    public void DestroyObj()
    {
        if (fade.complete)
        {
            Destroy(gameObject);
        }
    }
    

    public void PlayerAttackEnemy()
    {
        if (isHit)
        {
              enemyHealth += playerAttackDamage.value;
              onPlayerAttackEvent.Invoke();
        }
      
    }
    
    public void SetValueToTheMaxValue()
    {
        enemyHealth = enemyHealthMax;
    }
    
    public void SetImageFillAmount(Image img)
    {
        
        if (enemyHealth > 0 || enemyHealth <= enemyHealthMax)
        {
            img.fillAmount = enemyHealth / enemyHealthMax;
            imgFillEvent.Invoke();
        }

        if (enemyHealth <= 0)
        {
            lessThanZeroEvent.Invoke();
        }

        if (enemyHealth >= enemyHealthMax)
        {
            enemyHealth = enemyHealthMax;
        }
    }
}
