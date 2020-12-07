using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//CODE USED FROM WATCHING COMP-3 INTERACTIVE : https://www.youtube.com/watch?v=CUJO3tZ9P88&t=728s
public class DialogueSystem : MonoBehaviour
{
  public Text speakerName, dialogue;
  public Image speakerSprite;
  public GameObject continueButton;
  public Speaker player;
  public bool convoIsFinished;
  public UnityEvent onConvoFinish;

  private int currentIndex;
  private Conversation currentConvo;
  private static DialogueSystem instance;
  private Animator anim;
  private Coroutine typing;
  private int clickCount;
  private bool complete;


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

  private void Update()
  {
    if (complete)
    {
      continueButton.SetActive(true);
    }
  }

  public void OnClick()
  {
    currentIndex++;
    ReadNext();
  }

  public static void StartConversation(Conversation convo)
  {
    instance.convoIsFinished = false;
    instance.anim.SetBool("isOpen", true);
    instance.currentIndex = 0;
    instance.currentConvo = convo;
    instance.speakerName.text = "";
    instance.dialogue.text = "";

    instance.ReadNext();
  }

  public void ReadNext()
  {
    continueButton.SetActive(false);
    if (currentIndex > currentConvo.GetLength())
    {
      anim.SetBool("isOpen", false);
      instance.convoIsFinished = true;
      instance.onConvoFinish.Invoke();

      //old event system
      // if (eventCount < nextActions.Length-1 && nextActions[eventCount] != null)
      // {
      //   nextActions[eventCount].Invoke();
      //   eventCount++;
      // }
      // else
      // {
      //   nextActions[eventCount].Invoke();
      // }
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

  IEnumerator TypeText(string text)
  {
    
    dialogue.text = "";
    complete = false;
    int index = 0;
    
// my own code, inputs player name when I use <> i'm so proud
    while (!complete)
    {
      int a = 0;
      if (text[index] == '[')
      {
        while (text[index] != ']')
        {
          dialogue.text += player.speakerName;
          index++;
        }

        if (text[index] == ']')
        {
          index++;
        }
      }
      if (text[index] == '<')
      {
        while (text[index] != '>')
        {
          index++;
          a++;
        }

        if (text[index] == '>')
        {
          index = a + 2;
        }
      }

      dialogue.text += text[index];
        index++;
        yield return new WaitForSeconds(.02f);


        if (index == text.Length)
      {
        complete = true;
      }
    }

    typing = null;
  }
}
