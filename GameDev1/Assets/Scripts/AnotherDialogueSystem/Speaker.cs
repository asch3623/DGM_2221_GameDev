using UnityEngine;
//CODE USED FROM WATCHING COMP-3 INTERACTIVE : https://www.youtube.com/watch?v=CUJO3tZ9P88&t=728s

[CreateAssetMenu(fileName = "New Speaker", menuName = "Dialogue/New Speaker")]
public class Speaker : ScriptableObject
{
  [SerializeField] private string speakerName;
  [SerializeField] private Sprite speakerSprite;

  public string getName()
  {
    return speakerName;
  }

  public Sprite getSprite()
  {
    return speakerSprite;
  }
}
