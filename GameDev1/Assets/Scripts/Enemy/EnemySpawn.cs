using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private EnemyAI ai;

    private void Start()
    {
        ai = gameObject.transform.GetChild(0).gameObject.GetComponent<EnemyAI>();
        enemyObj = gameObject.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
        enemy = enemyObj.GetComponent<EnemyBehaviour>();
        fade = enemyObj.GetComponent<TransparencyFade>();
        col = enemyObj.GetComponent<Collider>();
    }

    public void BringBack()
    {
        ai.enabled = false;
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
        ai.enabled = true;
        yield return new WaitForSeconds(wait);
    }

}
