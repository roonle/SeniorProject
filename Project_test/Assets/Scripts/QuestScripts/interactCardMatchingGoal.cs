using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New cardminigamewintracker", menuName = "CreateQuest/cardminigamewintracker")]
public class interactCardMatchingGoal : Goal
{
    public GameObject winTracker;
    //private Transform gameobjectpos;
    
    
    
    public override void Init()
    {
        Instantiate(winTracker);
        winTracker.GetComponent<dontdestroyonloadscipt>().delete = false;
        checkWinTracker();
    }


    public void checkWinTracker()
    {
        if (winTracker.GetComponent<TextMesh>().text != "")
        {
            string numtext = winTracker.GetComponent<TextMesh>().text;
            int num = Int32.Parse(numtext);
            if (num > 0)
            {
                Current++;
                evaluate();
                winTracker.GetComponent<dontdestroyonloadscipt>().delete = true;
            }
            
        }
        

    }
}

