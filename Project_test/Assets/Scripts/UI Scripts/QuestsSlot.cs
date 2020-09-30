using System;
using UnityEngine.UI;
using UnityEngine;

public class QuestsSlot : MonoBehaviour
{
    public Text questName;
    public Text questDescription;
    public Button removeButton;
    
    private Quest quest;

    

    public void addQuest(Quest newQuest)
    {
        quest = newQuest;

        questName.text = quest.QuestName;
        questDescription.text = quest.Description;
        removeButton.interactable = true;
    }

    public void clearSlot()
    {
        quest = null;

        questName.text =  null;
        questDescription.text = null;
        
        removeButton.interactable = false;
        
    }

    public void onRemoveButton()
    {
        QuestInventory.instance.Remove(quest);
        
    }



}
