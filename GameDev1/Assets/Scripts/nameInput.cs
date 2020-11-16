using UnityEngine;
using UnityEngine.UI;
public class nameInput : MonoBehaviour
{

    public string name;
    public InputField inputName;

    public Speaker player;
    

    public void StoreName()
    {
        player.speakerName = inputName.text;
    }

}
