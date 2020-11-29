using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Animator))]
public class WeaponBehavior : MonoBehaviour
{
   public UnityEvent AttackEnemy;
   public Equipment weapon;
   
   
   private Animator anim;
   private int attackDamage;
   private int defense;
   private float seconds = 0.5f;
   private bool isAttacking, inRange;
   


   private void Start()
   {
      anim = GetComponent<Animator>();
      attackDamage = weapon.attackDamage;
      defense = weapon.defense;
      isAttacking = false;
      inRange = false;
   }
   

   private void Update()
   {
      if (Input.GetButtonDown("Fire1") && isAttacking == false)
      {
         //if player is in range, decrease enemy health.
         if (inRange)
         {
            Debug.Log("is Attacking Enemy");
            AttackEnemy.Invoke();
         }
         
         
         StartCoroutine(Attack());
      }
   }

   private IEnumerator Attack()
   {
      isAttacking = true;
      anim.SetBool("isAttacking", true);
      yield return new WaitForSeconds(seconds);
      anim.SetBool("isAttacking", false);
      isAttacking = false;

   }
}
