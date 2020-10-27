using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// all code was made following a Brackey's tutorial, https://www.youtube.com/watch?v=_nRzoTzeyxU
public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public Animator anim;
    public Text nameText, dialogueText;
    void Start()
    {
        sentences = new Queue<string>();
        anim.SetBool("isOpen", false);
    }

    
    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        anim.SetBool("isOpen", true);
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
        sentences.Enqueue(sentence);    
        }

        DisplayNextSentence();
    }

   public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentenceLetters(sentence));
    }

    IEnumerator TypeSentenceLetters (string sentence)
    {
       dialogueText.text = " ";
       foreach (char letter in sentence.ToCharArray())
       {
           dialogueText.text += letter;
           yield return null;
       }
    }
    
   public void EndDialogue()
   {
       anim.SetBool("isOpen", false);
   }
    
}
