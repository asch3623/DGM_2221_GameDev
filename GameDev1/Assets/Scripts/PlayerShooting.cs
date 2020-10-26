using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{

    public IntData ammoCount;
    public IntData maxAmmo;
    public GameObject prefab;
    public Transform instancer;
    public float reloadTime;
    public WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    public Image coolDownImage;
    private bool canShoot = true;

    private void Start()
    {
        
        coolDownImage.fillAmount = 0;
        ammoCount.value = maxAmmo.value;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammoCount.value > 0 && canShoot)
        {
            fire();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());
        }
    }

    private void fire()
    {
        
        Instantiate(prefab, instancer.position , instancer.rotation);
        ammoCount.value--;
        
        if (ammoCount.value == 0)
        {
            StartCoroutine(reload());

        }
    }

    private IEnumerator reload()
    {
        canShoot = false;
        var countDown = reloadTime;
        while (countDown > 0)
        {
            yield return wffu;
            countDown -= .01f;
            coolDownImage.fillAmount = countDown / reloadTime;
        }
      
        ammoCount.value = maxAmmo.value;
        canShoot = true;
    }
}