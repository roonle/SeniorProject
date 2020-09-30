using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInventory : MonoBehaviour
{
    #region Singleton

    public static QuestInventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("warning more than one instance of Questinventory");
            return;
        }

        instance = this;
        
    }

    #endregion

    public void Start()
    {
        
        loadList = SaveSystem.loadQuestInventory();
        quests = new List<Quest>();

    }

    public delegate void OnQuestChanged();

    public OnQuestChanged onQuestChangedCallback;
    public int space = 9;
    public List<Quest> quests;
    public List<SavedQuest> loadList;

    public bool Add(Quest quest)
    {
        if (quests.Count >= space)
        {
            Debug.Log("complete some current missions in order to receive more");
            return false;
        }
        quests.Add(quest);

        if (onQuestChangedCallback != null)
            onQuestChangedCallback.Invoke();

        return true;
    }
    public void AddQuest(Quest quest)
    {
        if (quests.Count >= space)
        {
            Debug.Log("complete some current missions in order to receive more");
            return;
        }

        quests.Add(quest);

        if (onQuestChangedCallback != null)
            onQuestChangedCallback.Invoke();
        
    }

    public void Remove(Quest quest)
    {
        
        quests.Remove(quest);
        if (onQuestChangedCallback != null)
            onQuestChangedCallback.Invoke();
    }

    public void saveQuestInventory()
    { 
        List<SavedQuest> list = new List<SavedQuest>();
        for (int i = 0; i < quests.Count; i++)
        {
            list.Add(new SavedQuest(quests[i]));
        }
        SaveSystem.saveQuestInventory(list);
    }
    
}