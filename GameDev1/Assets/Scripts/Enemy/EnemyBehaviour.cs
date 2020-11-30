using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


[RequireComponent(typeof(TransparencyFade))]
public class EnemyBehaviour : MonoBehaviour
{
    public IntData playerAttackDamage;
    public float enemyHealth, enemyHealthMax;
    public UnityEvent onPlayerAttackEvent;

    public List<GameObject> lootItems;
    public int[] table =
    {
        60,
        30,
        10
    };

    private int total;
    
    
    private int seconds = 1;
    private TransparencyFade fade;
    private Vector3 pos;

    private void Start()
    {
        pos = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        fade = GetComponent<TransparencyFade>();
    }

    public void InstantiateObj()
    {
        Instantiate(gameObject, pos, gameObject.transform.rotation);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Projectile"))
        {
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(seconds);
    }


    public void DestroyObj()
    {
        if (fade.complete)
        {
            RandomItemDrop();
            Destroy(gameObject);
        }
    }
    

    public void PlayerAttackEnemy()
    {
        if (enemyHealth > 0)
        {
             enemyHealth += playerAttackDamage.value;
             onPlayerAttackEvent.Invoke();
        }

        if (enemyHealth <= 0)
        {
            onPlayerAttackEvent.Invoke();
        }
        
       

    }
    
    public void SetValueToTheMaxValue()
    {
        enemyHealth = enemyHealthMax;
    }

    public void RandomItemDrop()
    {
        foreach (var item in table)
        {
          total += item;  
        }
        
        int randomNumber = Random.Range(0, total);
        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                Instantiate(lootItems[i], gameObject.transform.position, Quaternion.identity);
                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }
    }
}
