using UnityEngine;

[CreateAssetMenu]
public class BoolData : ScriptableObject
{
   public bool value;

   public void ChangeValue(bool active)
   {
      value = active;
   }
}
