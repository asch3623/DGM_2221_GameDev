using System;
using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private EnemyBehaviour enemy;
    private int seconds = 30;
    private int wait = 1;
    private GameObject enemyObj;
    public EnemyUIBehaviour healthUi;
    private TransparencyFade fade;
    private int transparency = 1;
    private Collider col;

    private void Start()
    {
        enemy = gameObject.transform.GetComponentInChildren<EnemyBehaviour>();
        enemyObj = gameObject.transform.GetChild(0).transform.gameObject;
        fade = enemyObj.GetComponent<TransparencyFade>();
        col = enemyObj.GetComponent<Collider>();
    }

    public void BringBack()
    {
        fade.complete = false;
            StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        yield return new WaitForSeconds(seconds);
        enemyObj.SetActive(true);
        enemy.isDead = false;
        col.enabled = true;
        
        fade.mesh.material.color = new Color(fade.mColor.r, fade.mColor.g, fade.mColor.b, transparency);

        enemy.SetValueToTheMaxValue();
        healthUi.UpdateValue();
        yield return new WaitForSeconds(wait);
    }
    
}
