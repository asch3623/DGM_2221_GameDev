using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


[RequireComponent(typeof(Animator))]
public class WeaponBehavior : MonoBehaviour
{
   public UnityEvent imageChangeZ, imageChangeX, imageOldZ, imageOldX;
   public Equipment weapon;
   public IntData attackDamage;

   
   private Animator anim;
   private int defense;
   private bool isCoolDown, animState;




   private void Start()
   {
      anim = GetComponent<Animator>();
      attackDamage.value = weapon.attackDamage;
      defense = weapon.defense;
      animState = anim.GetCurrentAnimatorStateInfo(0).IsName("StickIdle");



   }
   

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Z))
      {
         anim.SetTrigger("Base_Attack");
         attackDamage.value = weapon.attackDamage;
         imageChangeZ.Invoke(); 
         imageOldZ.Invoke();  
      }
      if (Input.GetKeyDown(KeyCode.X) && isCoolDown == false)
      {
         anim.SetTrigger("Secondary_Attack");
         var weaponPowerUP = weapon.attackDamage *2;
         attackDamage.value = weaponPowerUP;
         imageChangeX.Invoke(); 
         StartCoroutine(coolDown(3));
      }
   }
   

   private IEnumerator coolDown(int seconds)
   {
      isCoolDown = true;
      yield return new WaitForSeconds(seconds);
      imageOldX.Invoke();
      isCoolDown = false;
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Enemy")
      {
         if (other.GetComponent<EnemyBehaviour>() == null)
         {
            other.transform.parent.GetComponent<EnemyBehaviour>().PlayerAttackEnemy();
         }
         else
         {
            other.GetComponent<EnemyBehaviour>().PlayerAttackEnemy();
         }
      }
      
   }
}
