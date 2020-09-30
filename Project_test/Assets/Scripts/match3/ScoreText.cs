using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    public Text scoreTxt;
    public int score = 0;
    public Text streakTxt;
    public int streak = 0;
    public int turnsLeft = 20;
    public Text turnsText;
    public int level = 1;
    public Text levelsText;

    // Start is called before the first frame update
    void Start()
    {
        //scoreTxt = GameObject.Find("Score").GetComponent<Text>();
        //streakTxt = GameObject.Find("Combo").GetComponent<Text>();
        scoreTxt.text = score.ToString();
        streakTxt.text = "" + streak;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score:" + score.ToString();
        streakTxt.text = "Combo: " + streak;
        turnsText.text = "Turns Remaining: " + turnsLeft;
        levelsText.text = "Level: " + level;
    }

    public void incScore(int amt)
    {
        score += amt;
        if (score % 1000 == 0)
        {
            level++;
            turnsLeft += 20;
        }
    }

    public void setStreak(int streak)
    {
        this.streak = streak;
    }

    public void updateTurns()
    {
        turnsLeft--;
        if (turnsLeft == 0)
        {
            SceneManager.LoadScene("final_scene");
        }
    }
}
