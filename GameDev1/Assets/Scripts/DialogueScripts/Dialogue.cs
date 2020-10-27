using UnityEngine;
[System.Serializable]
public class Dialogue
{
    // all code was made following a Brackey's tutorial, https://www.youtube.com/watch?v=_nRzoTzeyxU
    public string name;
    
    [TextArea(3,10)]
    public string[] sentences;
}
