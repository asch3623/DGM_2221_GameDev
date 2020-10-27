using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
   // all code was made following a Brackey's tutorial, https://www.youtube.com/watch?v=_nRzoTzeyxU
   public Dialogue dialogue;

   public void TriggerDialogue()
   {
      FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
   }
}
