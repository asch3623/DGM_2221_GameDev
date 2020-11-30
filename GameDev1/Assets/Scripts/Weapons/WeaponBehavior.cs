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

   public int seconds = 3;
   private Animator anim;
   private int defense;
   private bool isCoolDown;
   



   private void Start()
   {
      anim = GetComponent<Animator>();
      attackDamage.value = weapon.attackDamage;
      defense = weapon.defense;
      
      
      
   }
   

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Z))
      {
         anim.SetTrigger("Base_Attack");
         imageChangeZ.Invoke(); 
      }
      if (Input.GetKeyDown(KeyCode.X) && isCoolDown == false)
      {
         imageChangeX.Invoke(); 
         var weaponPowerUP = weapon.attackDamage *2;
         attackDamage.value = weaponPowerUP;
         anim.SetTrigger("Secondary_Attack");
         StartCoroutine(coolDown());
      }

      if (anim.GetCurrentAnimatorStateInfo(0).IsName("StickIdle"))
      {
         imageOldZ.Invoke();  
         attackDamage.value = weapon.attackDamage;
      }
   }
   

   private IEnumerator coolDown()
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
