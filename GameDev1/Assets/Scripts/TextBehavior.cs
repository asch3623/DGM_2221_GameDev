using System;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class TextBehavior : MonoBehaviour
{
  public IntData data;
  private Text t;
  public string message;

  private void Start()
  {
    t = GetComponent<Text>();
    t.text = message + data.value;
  }

  public void UpdateText()
  {
    t.text = message + data.value;
  }
}
