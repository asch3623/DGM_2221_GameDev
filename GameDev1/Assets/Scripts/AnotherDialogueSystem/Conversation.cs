using UnityEngine;

//CODE USED FROM WATCHING COMP-3 INTERACTIVE : https://www.youtube.com/watch?v=CUJO3tZ9P88&t=728s
[CreateAssetMenu(fileName = "New Conversation", menuName = "Dialogue/New Conversation")]
public class Conversation : ScriptableObject
{
   [SerializeField] private DialogueLine[] allLines;

   public DialogueLine GetLineByIndex(int index)
   {
      return allLines[index];
   }

   public int GetLength()
   {
      return allLines.Length - 1;
   }
}
