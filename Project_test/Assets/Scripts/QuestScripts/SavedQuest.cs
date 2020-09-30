using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[System.Serializable]
public class SavedQuest
    {
        public List<SavedGoals> Goals;
        public string QuestName;
        public string Description;
        public int reward;
        public bool completed;
        
        public SavedQuest(Quest q)
        {
            questName = q.QuestName;
            Description = q.Description;
            reward = q.reward;
            completed = q.completed;
            Goals = getGoalList(q.Goals);
            
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

        private List<SavedGoals> getGoalList(List<Goal> l)
        {
            List<SavedGoals> list = new List<SavedGoals>();

            for (int i = 0; i < l.Count; i++)
            {
                list.Add(new SavedGoals(l[i]));
            }

            return list;
        }
    }
