using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Quest", menuName = "CreateQuest/Quest")]
public class Quest : ScriptableObject
{
    public List<Goal> Goals = new List<Goal>();
    public string QuestName;
    public string Description;
    public int reward;
    public bool completed;
    
    
    public void CheckGoals()
    {
        completed = (Goals.All(g => g.Completed));
    }

    public void initGoals()
    {
        Goals.ForEach(g => g.Init());
    }

    public void GiveReward()
    {
        ScoreUI.score += reward;
    }

    public string questName
    {
        
        set => QuestName = value;
    }

    public string description
    {
        
        set => Description = value;
    }

    public int reward1
    {
        
        set => reward = value;
    }

    public bool completed1
    {
        
        set => completed = value;
    }
}
