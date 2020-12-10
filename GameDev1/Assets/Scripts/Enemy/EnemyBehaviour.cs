using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
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

    private int seconds = 1, total;
    private TransparencyFade fade;
    private Vector3 pos;
    public List<GameObject> lootItems;
    public int[] table =
    {
        60,
        30,
        10
    };

    private void Start()
    {
        fade = GetComponent<TransparencyFade>();
        spawn = gameObject.transform.parent.transform.parent.gameObject.GetComponent<EnemySpawn>();
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
            isDead = true;
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

    public virtual void RandomItemDrop()
    {
        int count = 0;

        foreach (var item in table)
        {
            count += item;
              
        }
        total = count;
        int randomNumber = Random.Range(0, total);
        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                print("will drop loot");
                var obj = Instantiate(lootItems[i], gameObject.transform.position, gameObject.transform.rotation);
                gameObject.transform.position = obj.transform.position;
                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }
        
    }
    
}
