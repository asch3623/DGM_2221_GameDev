using System;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class TextBehavior : MonoBehaviour
{
  public IntData lifeCount;
  private Text t;

  private void Start()
  {
    t = GetComponent<Text>();
  }

  private void Update()
  {
    t.text = "Lives: " + lifeCount.value;
  }
}
