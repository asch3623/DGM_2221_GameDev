using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance : MonoBehaviour
{
   public void InstanceObj(GameObject obj)
   {
      Instantiate(obj, gameObject.transform);
   }
}
