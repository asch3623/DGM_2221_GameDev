using System;
using UnityEngine;
using UnityEngine.Events;

//CODE USED FROM WATCHING COMP-3 INTERACTIVE : https://www.youtube.com/watch?v=CUJO3tZ9P88&t=728s
public class Tester : MonoBehaviour
{
   public Conversation convo;
public UnityEvent convoOnStartAction, finishAction;
private DialogueSystem dialogueSystem;
private bool isThisConvo;
   private void Start()
   {
      dialogueSystem = GameObject.Find("DialogueBox").GetComponent<DialogueSystem>();
      convoOnStartAction.Invoke();
   }

   

   public void StartConversation()
   {
      isThisConvo = true;
      DialogueSystem.StartConversation(convo);
      
   }

   public void ConversationEnd()
   {
      if (dialogueSystem.convoIsFinished && isThisConvo)
      {
       finishAction.Invoke();
       isThisConvo = false;
      }
   }
}
