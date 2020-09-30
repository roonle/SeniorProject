using UnityEngine;
//create goal
public class Goal: ScriptableObject
{ 
    public string Description;
    public bool Completed;
    public int Current;
    public int Required;
    public int typeOfGoal;
    
    
    public virtual void Init()
    {
        
    }
    
    public void evaluate()
    {
        if (Current >= Required)
        {
            Completed = true;
        }
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
