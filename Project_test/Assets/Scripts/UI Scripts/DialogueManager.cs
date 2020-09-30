using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    
    private Queue<string> sentences;
    public new GameObject gameObject;
    private PlayerController player;
    private int part;
    
    void Start()
    {
        sentences = new Queue<string>();
        gameObject = GameObject.FindGameObjectWithTag("Dialoguebox");
        gameObject.SetActive(false);
        player = FindObjectOfType<PlayerController>();
        part = 0;
    }

    public void StartDialogue(DialogueParts dialoguepart)
    {
        
        gameObject.SetActive(true);
        player.canMove = false;
        nameText.text = dialoguepart.name;

        sentences.Clear();

        foreach (string sentence in dialoguepart.dialogue[part].sentences)
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
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");
        gameObject.SetActive(false);
        player.canMove = true;
    }

    public void setPart(int num)
    {
        part = num-1;
    }

}


















