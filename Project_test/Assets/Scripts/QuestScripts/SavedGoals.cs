using UnityEngine;
[System.Serializable]
public class SavedGoals
    {
        public string Description;
        public bool Completed;
        public int Current;
        public int Required;
        private int typeOfGoal;

        

        public SavedGoals (Goal g)
        {
            Description = g.Description;
            Completed = g.Completed;
            current = g.Current;
            required = g.Required;
            typeOfGoal = g.typeOfGoal;

        }
        
        
        
        public string description
        {
            set => Description = value;
        }

        public bool completed
        {
            set => Completed = value;
        }

        public int current
        {
            
            set => Current = value;
        }

        public int required
        {
            set => Required = value;
        }
        
        public int typeOfGoal1
        {
            get => typeOfGoal;
            set => typeOfGoal = value;
        }
        
    }
