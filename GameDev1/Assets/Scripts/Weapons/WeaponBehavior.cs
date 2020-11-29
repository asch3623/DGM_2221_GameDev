using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class WeaponBehavior : MonoBehaviour
{
   public Equipment weapon;
   private Animator anim;
   private int attackDamage;
   private int defense;
   private int secounds = 1;
   

   private void Start()
   {
      anim = GetComponent<Animator>();
      attackDamage = weapon.attackDamage;
      defense = weapon.defense;


   }

   private void Update()
   {
      if (Input.GetButtonDown("Fire1"))
      {
         Attack();
      }
   }

   private IEnumerator Attack()
   {
      anim.SetBool("isAttacking", true);
      yield return new WaitForSeconds(1);
      anim.SetBool("isAttacking", false);

   }
}
