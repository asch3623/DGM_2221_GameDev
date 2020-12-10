using System.Collections.Generic;
using UnityEngine;

public class ReplaceLootItems : MonoBehaviour
{
   private EnemyBehaviour enemy;
   public List<GameObject> originalLootItemList;

   private void Start()
   {
      enemy = GetComponent<EnemyBehaviour>();
   }

   public void ReplaceLoot(GameObject item)
   {
      for (int i = 0; i < enemy.lootItems.Count; i++)
      {
         enemy.lootItems[i] = item;
      }
   }

   public void OriginalLoot()
   {
      for (int i = 0; i < enemy.lootItems.Count-1; i++)
      {
         enemy.lootItems[i] = originalLootItemList[i];
      }
   }
}
