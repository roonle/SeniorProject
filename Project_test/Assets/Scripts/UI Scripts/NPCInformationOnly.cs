using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInformationOnly : Interactable
{
    public DialogueParts dialoguepart;
   

    public override void Interact()
    {
        base.Interact();
        TriggerDialogue();
    }

    void TriggerDialogue()
    {
        
        FindObjectOfType<DialogueManager>().setPart(1);
        FindObjectOfType<DialogueManager>().StartDialogue(dialoguepart);
        
        
    }
}


















