using UnityEngine;
using UnityEngine.Events;


public class TeleportObj : MonoBehaviour
{
   public UnityEvent teleport;
   public GameObject currentObj;

   public void TeleportObjtoPosition(GameObject targetTransform)
   {
      if (currentObj.GetComponent<CharacterController>() != null)
      {
        CharacterController cc = currentObj.GetComponent<CharacterController>();
        cc.enabled = false;
        currentObj.transform.position = targetTransform.transform.position;
        cc.enabled = true;

      }
      else
      {
          currentObj.transform.position = targetTransform.transform.position;
      }
   }

}
