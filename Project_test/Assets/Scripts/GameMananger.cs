using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameMananger : MonoBehaviour
{
    public int lives = 3;
    public Text gamePrompt;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    public  Image image1;
    public Image image2;
    public Image image3;
    public Image image4;

    public GameObject Result;

    public Button button1;

    public Button button2;

    public Button button3;

    public Button button4;

    public GameObject submit;

    public GameObject NextRound;

    public GameObject NextText;

    private int roundCounter = 1;

    public Sprite[] arraySprite;

    public GameObject[] arrayObject;

    


    // Start is called before the first frame update
    void Start()
    {
        slot1.SetActive(false);
        slot2.SetActive(false);
        slot3.SetActive(false);
        slot4.SetActive(false);
        slot5.SetActive(false);
        submit.gameObject.SetActive(false);
        Result.SetActive(false);
        NextRound.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckIt(){
            if(roundCounter == 1){
                if(EventSystem.current.currentSelectedGameObject.name.Equals("Button1")){
                    Debug.Log("correct");
                    
                    gamePrompt.text = "What is the Color of the Apple?";
                    slot1.SetActive(true);
                     slot2.SetActive(true);
                    slot3.SetActive(true);
                    submit.gameObject.SetActive(true);
                    DisableButtons();
                    
                }else{
                    Result.GetComponent<Text>().text = "Incorrect..";
                lives--;
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                
                NextText.GetComponent<Text>().text = lives.ToString() + " more lives, click here";
                NextRound.SetActive(true);
                DisableButtons();
                roundCounter++;
                }

            }else if(roundCounter == 2){
                 
                
                if(EventSystem.current.currentSelectedGameObject.name.Equals("Button2")){
                    Debug.Log("correct");
                    
                    gamePrompt.text = "What is the color is the bird?";
                    slot1.SetActive(true);
                     slot2.SetActive(true);
                    slot3.SetActive(true);
                    slot4.SetActive(true);
                    submit.gameObject.SetActive(true);
                    DisableButtons();
                    
                }else{
                    Result.GetComponent<Text>().text = "Incorrect..";
                lives--;
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                
                NextText.GetComponent<Text>().text = lives.ToString() + " more lives, click here";
                NextRound.SetActive(true);
                DisableButtons();
                roundCounter++;
                }
                 

            }else if(roundCounter == 3){
                if(EventSystem.current.currentSelectedGameObject.name.Equals("Button3")){
                    Debug.Log("correct");
                    
                    gamePrompt.text = "What is the color of the paper?";
                    slot1.SetActive(true);
                     slot2.SetActive(true);
                    slot3.SetActive(true);
                    slot4.SetActive(true);
                    slot5.SetActive(true);
                    submit.gameObject.SetActive(true);
                    DisableButtons();
                    
                }else{
                    Result.GetComponent<Text>().text = "Incorrect..";
                lives--;
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                
                NextText.GetComponent<Text>().text = lives.ToString() + " more lives, click here";
                NextRound.SetActive(true);
                DisableButtons();
                roundCounter++;
                }

            }else if(roundCounter == 4){
                if(EventSystem.current.currentSelectedGameObject.name.Equals("Button3")){
                    Debug.Log("correct");
                    
                    gamePrompt.text = "Can you spell this item?";
                    slot1.SetActive(true);
                     slot2.SetActive(true);
                    slot3.SetActive(true);
                    slot4.SetActive(true);
                    submit.gameObject.SetActive(true);
                    DisableButtons();
                    
                }else{
                    Result.GetComponent<Text>().text = "Incorrect..";
                lives--;
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                
                NextText.GetComponent<Text>().text = lives.ToString() + " more lives, click here";
                NextRound.SetActive(true);
                DisableButtons();
                roundCounter++;
                }

            }else if(roundCounter == 5){
                if(EventSystem.current.currentSelectedGameObject.name.Equals("Button4")){
                    Debug.Log("correct");
                    
                    gamePrompt.text = "What do you do in the forest? hint: starts with the letter H";
                    slot1.SetActive(true);
                     slot2.SetActive(true);
                    slot3.SetActive(true);
                    slot4.SetActive(true);
                    submit.gameObject.SetActive(true);
                    DisableButtons();
                    
                }else{
                    Result.GetComponent<Text>().text = "Incorrect..";
                lives--;
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                
                NextText.GetComponent<Text>().text = lives.ToString() + " more lives, click here";
                NextRound.SetActive(true);
                DisableButtons();
                roundCounter++;
                }
            }else if(roundCounter == 6){
                Debug.Log("you win");
                LevelLoader.winner = true;
            }
    }
    public void DisableButtons(){
        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;
        button4.interactable = false;
         
    }

    public void EnableButtons(){
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;
        button4.interactable = true; 
    }

    public void SubmitAnswer(){
        if(roundCounter == 1){
            
            if(slot1.GetComponent<Slot>().letter.Equals("R") && slot2.GetComponent<Slot>().letter.Equals("E") && slot3.GetComponent<Slot>().letter.Equals("D")){
                Result.GetComponent<Text>().text = "Correct!";
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                NextRound.SetActive(true);
                roundCounter++;
                
            }else{
                Result.GetComponent<Text>().text = "Incorrect..";
                lives--;
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                
                NextText.GetComponent<Text>().text = lives.ToString() + " more lives, click here";
                NextRound.SetActive(true);
                roundCounter++;
            }
        }else if(roundCounter == 2){
            if(slot1.GetComponent<Slot>().letter.Equals("B") && slot2.GetComponent<Slot>().letter.Equals("L") && slot3.GetComponent<Slot>().letter.Equals("U") && slot4.GetComponent<Slot>().letter.Equals("E")){
                Result.GetComponent<Text>().text = "Correct!";
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                NextRound.SetActive(true);
                roundCounter++;
                
            }else{
                Result.GetComponent<Text>().text = "Incorrect..";
                lives--;
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                
                NextText.GetComponent<Text>().text = lives.ToString() + " more lives, click here";
                NextRound.SetActive(true);
                roundCounter++;
            }

        }else if(roundCounter == 3){
            if(slot1.GetComponent<Slot>().letter.Equals("W") && slot2.GetComponent<Slot>().letter.Equals("H") && slot3.GetComponent<Slot>().letter.Equals("I")  && slot4.GetComponent<Slot>().letter.Equals("T")  && slot5.GetComponent<Slot>().letter.Equals("E")){
                Result.GetComponent<Text>().text = "Correct!";
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                NextRound.SetActive(true);
                roundCounter++;
                
            }else{
                Result.GetComponent<Text>().text = "Incorrect..";
                lives--;
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                
                NextText.GetComponent<Text>().text = lives.ToString() + " more lives, click here";
                NextRound.SetActive(true);
                roundCounter++;
            }

        }else if(roundCounter == 4){
            if(slot1.GetComponent<Slot>().letter.Equals("D") && slot2.GetComponent<Slot>().letter.Equals("E") && slot3.GetComponent<Slot>().letter.Equals("S")  && slot4.GetComponent<Slot>().letter.Equals("K")){
                Result.GetComponent<Text>().text = "Correct!";
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                NextRound.SetActive(true);
                roundCounter++;
                
            }else{
                Result.GetComponent<Text>().text = "Incorrect..";
                lives--;
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                
                NextText.GetComponent<Text>().text = lives.ToString() + " more lives, click here";
                NextRound.SetActive(true);
                roundCounter++;
            }

        }else if(roundCounter ==5){
           if(slot1.GetComponent<Slot>().letter.Equals("H") && slot2.GetComponent<Slot>().letter.Equals("I") && slot3.GetComponent<Slot>().letter.Equals("K")  && slot4.GetComponent<Slot>().letter.Equals("E")){
                Result.GetComponent<Text>().text = "Correct!";
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                NextRound.SetActive(true);
                roundCounter++;
                Debug.Log("you win");
                LevelLoader.winner = true;
                
            }else{
                Result.GetComponent<Text>().text = "Incorrect..";
                lives--;
                Result.SetActive(true);
                submit.gameObject.SetActive(false);
                
                NextText.GetComponent<Text>().text = lives.ToString() + " more lives, click here";
                NextRound.SetActive(true);
                roundCounter++;

                if(lives > 0){
                    Debug.Log("you win");
                LevelLoader.winner = true;
                }
            }
        
            
        }
    }

    public void Next(){
            reset();
            if(roundCounter == 2){
                
                EnableButtons();
                 image1.sprite = arraySprite[2];
                 image2.sprite = arraySprite[0];
                 image3.sprite = arraySprite[1];
                 image4.sprite = arraySprite[3];
                 gamePrompt.text = "Which picture is an Animal?";
                 
            }else if(roundCounter == 3){
                EnableButtons();
                 image1.sprite = arraySprite[5];
                 image2.sprite = arraySprite[6];
                 image3.sprite = arraySprite[4];
                 image4.sprite = arraySprite[7];
                 gamePrompt.text = "What do you use to write on?";

            }else if(roundCounter == 4){
                EnableButtons();
                 image1.sprite = arraySprite[11];
                 image2.sprite = arraySprite[10];
                 image3.sprite = arraySprite[9];
                 image4.sprite = arraySprite[8];
                 gamePrompt.text = "Which one of these objects you can find in School?";

            }else if(roundCounter == 5){
                EnableButtons();
                 image1.sprite = arraySprite[12];
                 image2.sprite = arraySprite[13];
                 image3.sprite = arraySprite[14];
                 image4.sprite = arraySprite[15];
                 gamePrompt.text = "What picture is a place?";

            }
    }

    public void reset(){
            slot1.SetActive(false);
                slot2.SetActive(false);
                slot3.SetActive(false);
                slot4.SetActive(false);
                  slot5.SetActive(false);
                submit.gameObject.SetActive(false);
                 Result.SetActive(false);
                NextRound.SetActive(false);
                for(int i = 0; i < 26; i++){
                arrayObject[i].transform.position = arrayObject[i].GetComponent<DragDrop>().spawnPos;
                  
                }
                
    }
}
