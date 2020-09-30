using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause1 : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseUI;
    public GameObject varGameObject;
    private GameObject thePlayer;
    private GameObject gamemanager;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();

            }
            else
            {

                Pause();

            }
        }
    }

    private void Start()
    {
        thePlayer = GameObject.Find("Player");
        gamemanager = GameObject.Find("GameManager");
    }

    public void Pause()
    {
        //GameObject varGameObject = GameObject.FindWithTag("Player");
        pauseUI.SetActive(true);
       // Cursor.visible = true;
        Time.timeScale = 0f;
        isPaused = true;
        //varGameObject.GetComponent<ThirdPersonCamera>().enabled = false;
    }

    public void Resume()
    {
        //GameObject varGameObject = GameObject.FindWithTag("Player");
        pauseUI.SetActive(false);
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        
        isPaused = false;
        Time.timeScale = 1f;
        //SceneManager.LoadScene("Test_project");
        //varGameObject.GetComponent<ThirdPersonCamera>().enabled = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Title");
    }

    public void Quit()
    {
        thePlayer.GetComponent<Player>().SavePlayer();
        gamemanager.GetComponent<QuestInventory>().saveQuestInventory();
        System.Console.WriteLine("does it hit SavePlayer");
        Application.Quit();
    }
}