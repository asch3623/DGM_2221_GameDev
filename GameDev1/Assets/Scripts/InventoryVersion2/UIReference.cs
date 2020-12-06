using UnityEngine;

public class UIReference: MonoBehaviour
{
 public static UIReference instance;

 private void Start()
 {
  instance = this;
 }
}
