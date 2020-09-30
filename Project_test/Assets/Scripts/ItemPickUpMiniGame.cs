
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemPickUpMiniGame : Interactable
{
    public string minigame;
    private GameObject gamemanager;
    private GameObject thePlayer;


    private void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        thePlayer = GameObject.Find("Player");
    }

    public override void Interact()
    {
        base.Interact();

        loadScene();
        
    }

    void loadScene()
    {
        Debug.Log("Pick up item " + minigame + " to load scene");
        if (QuestInventory.instance.quests != null)
        {
            gamemanager.GetComponent<QuestInventory>().saveQuestInventory();
        }
        thePlayer.GetComponent<Player>().SavePlayer();
        SceneManager.LoadScene(minigame);

    }
}
