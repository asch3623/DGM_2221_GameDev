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
    public bool isDead;
    private EnemySpawn spawn;

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
        fade = GetComponent<TransparencyFade>();
        spawn = gameObject.transform.parent.gameObject.GetComponent<EnemySpawn>();
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
            isDead = true;
            RandomItemDrop();
            spawn.BringBack();
            gameObject.SetActive(false);
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
        if (isDead)
        {
            print("is running function");
            
            foreach (var item in table)
            {
                total += item;  
            }
                    
            int randomNumber = Random.Range(0, total);
            for (int i = 0; i < table.Length; i++)
            {
                if (randomNumber <= table[i])
                {
                    print("is dropping loot");
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
}
