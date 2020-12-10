using UnityEngine;
using UnityEngine.UI;

public class CreateText : MonoBehaviour
{
    private Text t;
    public GameObject textUi;
    public void PrintText(string message)
    {
        t = textUi.GetComponent<Text>();
        t.text = message;
        Instantiate(textUi, UIReference.instance.transform);
    }
}
