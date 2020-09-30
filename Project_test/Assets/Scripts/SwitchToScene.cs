using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToRegister()
    {
        SceneManager.LoadScene(sceneName: "RegisterScene");
    }

    public void MoveToTitle()
    {
        SceneManager.LoadScene(sceneName: "Title");
    }

    public void MoveToMainGame()
    {
        SceneManager.LoadScene(sceneName: "Main");
    }

    public void MoveToTestProject()
    {
        SceneManager.LoadScene(sceneName: "Test_project");
    }



}