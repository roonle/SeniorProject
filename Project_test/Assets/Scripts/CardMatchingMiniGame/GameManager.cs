using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
//using UnityEngine.WSA;


public class GameManager : MonoBehaviour
{
    public const int rows = 2;
    public const int col = 4;
    public const float offsetx = 5f;
    public const float offsety = 5f;

    public GameObject winTrackerFinder;
    
    public delegate void InteractedDelegate();

    public static event InteractedDelegate InteractedEvent;


    private CircleCard firstCard;
    private CircleCard secondCard;
    private int score = 0;
    private int win = 0;


    [SerializeField] private TextMesh label;
    [SerializeField] private TextMesh message;
    [SerializeField] private CircleCard maincard;
    [SerializeField] private Sprite[] img;
    

    private void Start()
    {
        Vector3 sp = maincard.transform.position;

        if (GameObject.Find("wins object(Clone)") != null)
        {
            winTrackerFinder = GameObject.Find("wins object(Clone)");
        }
        
        

        int[] num = {0, 0, 1, 1, 2, 2, 3, 3};
        num = shuffleArr(num);
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                CircleCard c;
                if (i == 0 && j == 0)
                {
                    c = maincard;
                }
                else 
                    c = (CircleCard)Instantiate(maincard);

                int arrayindex = j * col + i;
                int id = num[arrayindex];
                c.changeImage(id,img[id]);
                
                float x = (offsetx * i) + sp.x;
                float y = (offsety * j) + sp.y;
                
                c.transform.position = new Vector3(x,y,sp.z);
            }
        }
        
    }

    private int[] shuffleArr(int[] array)
    {
        int[] arr = (int[])array.Clone();

        for (int i = 0; i < arr.Length; i++)
        {
            int tmp = arr[i];
            int randomindex = Random.Range(i, arr.Length);
            arr[i] = arr[randomindex];
            arr[randomindex] = tmp;
        }
        return arr;
    }


    public bool canReveal()
    {
        if (secondCard == null)
        {
            return true;
        }
        else
            return false;
    }
    
    public void revealedCard(CircleCard card){
        if (firstCard == null)
        {
            firstCard = card;
        }
        else
        {
            secondCard = card;
            StartCoroutine(checkMatch());

        }
        
    }

    private IEnumerator checkMatch()
    {
        if (firstCard.id == secondCard.id)
        {
            score++;
            label.text = "Score: " + score;
        }
        else
        {
            yield return new WaitForSeconds(.8f);
            firstCard.unreveal();
            secondCard.unreveal();
        }

        firstCard = null;
        secondCard = null;
        checkForWin();
    }

    public void restartGame()
    {
        DestroyOrNot();
        
        SceneManager.LoadScene("GameScene");
    }

    public void exitGame()
    {

        DestroyOrNot();
        if (InteractedEvent != null)
        {
            InteractedEvent();
        }
        SceneManager.LoadScene("final_scene");
    }

    public void DestroyOrNot()
    {
        if (win > 0 && winTrackerFinder != null)
        {
            if (winTrackerFinder.GetComponent<TextMesh>().text != "")
            {
                string numtext = winTrackerFinder.GetComponent<TextMesh>().text;
                int num = Int32.Parse(numtext);
                int newwins = num + win;
                winTrackerFinder.GetComponent<TextMesh>().text = newwins.ToString();
                
            }
            else
            {
                winTrackerFinder.GetComponent<TextMesh>().text = win.ToString();
            }
            //DontDestroyOnLoad(winTrackerFinder);
        }
        else
        {
            Destroy(winTrackerFinder);
        }
    }

    private void checkForWin()
    {
        if (score == 4)
        {
            message.text = "You Win!! Click Play again to play another Round \n or click Exit to leave the game and go back";
            win++;

        }
    }
    
}


