using UnityEngine;
//CODE USED FROM WATCHING COMP-3 INTERACTIVE : https://www.youtube.com/watch?v=CUJO3tZ9P88&t=728s
public class Tester : MonoBehaviour
{
   public Conversation convo;

   public void StartConversation()
   {
      DialogueSystem.StartConversation(convo);
   }
}
