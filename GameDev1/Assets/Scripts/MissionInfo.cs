using UnityEngine;
using UnityEngine.UI;

public class MissionInfo : MonoBehaviour
{
  public StringData missionText;
  private Text currentText;
  

  public void UpdateText(string text)
  {
    currentText = GetComponent<Text>();
    missionText.text = text;
    currentText.text = "Mission: " + missionText.text;
  }
}
