using UnityEngine;
using UnityEngine.UI;

public class MissionInfo : MonoBehaviour
{
  public StringData missionText;
  private Text currentText;
  public IntData count;
  public IntData maxCount;
  

  public void UpdateText(string text)
  {
    currentText = GetComponent<Text>();
    missionText.text = text;
    currentText.text = "Mission: " + missionText.text;
  }

  public void ShowMissionCount()
  {
    currentText.text = "Mission: " + missionText.text + count.value + "/" + maxCount.value;
  }
}
