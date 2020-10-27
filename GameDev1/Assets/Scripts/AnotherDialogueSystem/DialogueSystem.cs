using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//CODE USED FROM WATCHING COMP-3 INTERACTIVE : https://www.youtube.com/watch?v=CUJO3tZ9P88&t=728s
public class DialogueSystem : MonoBehaviour
{
  public Text speakerName, dialogue;
  public Image speakerSprite;
  
  private int currentIndex;
  private Conversation currentConvo;
  private static DialogueSystem instance;
  private Animator anim;
  private Coroutine typing;
  private int clickCount;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
      anim = GetComponent<Animator>();
    }
    else
    {
      Destroy(gameObject);
    }
  }

//MY OWN CODE, I wanted to make it so the continue button didn't move on until dialogue was fully shown, so you must click multiple times, once to show all dialogue and next to move on.
  public void OnClick()
  {
    clickCount++;
    if (clickCount == 1)
    {
      if (currentIndex > currentConvo.GetLength())
      {
        anim.SetBool("isOpen", false);
        return;
      }
      FinishSentence();
    }

    if (clickCount == 2)
    {
      currentIndex++;
      ReadNext();
      clickCount = 0;
    }
  }
  public static void StartConversation(Conversation convo)
  {
    instance.anim.SetBool("isOpen", true);
    instance.currentIndex = 0;
    instance.currentConvo = convo;
    instance.speakerName.text = "";
    instance.dialogue.text = "";
    
    instance.ReadNext();
  }
  
  public void ReadNext()
  {
    if (currentIndex > currentConvo.GetLength())
    {
      anim.SetBool("isOpen", false);
      return;
    }

    speakerName.text = currentConvo.GetLineByIndex(currentIndex).speaker.getName();
    if (typing == null)
    {
      typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
      
    }
    else
    {
      instance.StopCoroutine(typing);
      typing = null;
      typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
    }
    speakerSprite.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.getSprite();
  }

  
  //my own code!! This shops the slow type and just shows all text.
  public void FinishSentence()
  {
    instance.StopCoroutine(typing);
    typing = null;
    dialogue.text = currentConvo.GetLineByIndex(currentIndex).dialogue;
  }

  IEnumerator TypeText(string text)
  {
    dialogue.text = "";
    bool complete = false;
    int index = 0;
    
    while (!complete)
    {
      dialogue.text += text[index];
      index++;
      yield return new WaitForSeconds(.02f);
      

      if (index == text.Length - 1)
      {
        complete = true;
      }
    }

    typing = null;
  }
}
