using UnityEngine;
[System.Serializable]

//CODE USED FROM WATCHING COMP-3 INTERACTIVE : https://www.youtube.com/watch?v=CUJO3tZ9P88&t=728s
public class DialogueLine
{
    public Speaker speaker;
    [TextArea(3, 10)]
    public string dialogue;
}
