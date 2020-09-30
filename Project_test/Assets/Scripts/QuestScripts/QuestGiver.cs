using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : Interactable
{
    public DialogueParts dialoguepart;
    public bool questAssigned;
    public bool questCompleted;
    public Quest quest;
    private DialogueManager _dialogueManager;
    


    void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public override void Interact()
    {
        checkQuestRepeat();
        checkQuest();
        if (!questAssigned && !questCompleted)
        {
            base.Interact();
            AssignQuest();
        }
        else if (questAssigned && !questCompleted)
        {
            FindObjectOfType<DialogueManager>().setPart(3);
            TriggerDialogue(); 
        }
        else if (questAssigned && questCompleted)
        {
            FindObjectOfType<DialogueManager>().setPart(2);
            TriggerDialogue();
            quest.GiveReward();
            questAssigned = false;
            Debug.Log("QUEST FINISHED");
        }
        else
        {
            _dialogueManager.setPart(4);
            TriggerDialogue();
        }
    }

    private void checkQuestRepeat()
    {
        for (int x = 0; x < QuestInventory.instance.loadList.Count; x++)
        {

            if (QuestInventory.instance.loadList[x].completed && quest.QuestName.Equals(QuestInventory.instance.loadList[x].QuestName))
            {
                questCompleted = true;
                questAssigned = true;
                
            }

            if (!QuestInventory.instance.loadList[x].completed && quest.QuestName.Equals(QuestInventory.instance.loadList[x].QuestName))
            {
                questAssigned = true;
                if (!QuestInventory.instance.quests[x].Equals(quest.QuestName))
                {
                    QuestInventory.instance.AddQuest(quest);
                }
                quest.initGoals();
                
            }
        }
    }

    public void TriggerDialogue()
    {
        _dialogueManager.StartDialogue(dialoguepart);
    }

    public void AssignQuest()
    {
        hasInteracted = true;
        questAssigned = true;
        bool wasPickedUp = QuestInventory.instance.Add(quest);
        if (!wasPickedUp)
        {
            _dialogueManager.setPart(5);
            TriggerDialogue();
            hasInteracted = false;
            questAssigned = false;
            return;
        }
        quest.initGoals();
        _dialogueManager.setPart(1);

        TriggerDialogue();

        Debug.Log("QUEST STARTED");
    }

    public void checkQuest()
    {
        quest.CheckGoals();
        if (quest.completed)
        {
            questCompleted = true;
            QuestInventory.instance.Remove(quest);
        }
        
    }


}