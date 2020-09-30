using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Scene scene;
    
    public void SavePlayer(){

        SaveSystem.SavePlayer(this);

    }

    void Start(){
        
        PlayerData data = SaveSystem.LoadPlayer();

        if(data != null){
        Vector3 position;

        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        
        Quaternion rotation;
        
        rotation.x = data.rotation[0];
        rotation.y = data.rotation[1];
        rotation.z = data.rotation[2];
        rotation.w = data.rotation[3];
        transform.rotation = rotation; 
        }
    }

}