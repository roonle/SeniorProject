﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
   public Animator transition;
   public float transitionTime = 1f;
   
   public static bool winner = false;

   public static bool main = false;
    // Update is called once per frame
    void Update()
    {
        if(winner)
        {
            LoadNextLevel();
            winner = false;
        }

        if(main)
        {
            LoadNextLevel();
            main=false;
        }
    }

    public void LoadNextLevel()
    {
        if(main){
            StartCoroutine(LoadLevel("final_scene"));
        }
        if(winner){
        StartCoroutine(LoadLevel("CongratulationScene"));
        }
    }
    IEnumerator LoadLevel(string level)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(level);
    }



    
}
