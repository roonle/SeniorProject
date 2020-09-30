using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audiom;
    public static bool isPaused;
    public GameObject pauseUI;
    Resolution[] resolutions;
    public Dropdown resolutionDropDown;
    public TMP_Dropdown qualityDropDown;

    public void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();
        List<string> resolutionOptions = new List<string>();
        int curResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionOptions.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                curResIndex = i;
            }
        }
        resolutionDropDown.AddOptions(resolutionOptions);
        resolutionDropDown.value = curResIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void setVolume(float volume)
    {
        //Debug.Log(volume);
        audiom.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void setQaulity(int qualityIndex)
    {
        //qualityIndex = qualityDropDown.value;
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log(qualityIndex);
    }

    public void setFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void setResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

                Resume();

        }
    }

    public void Resume()
    {

        pauseUI.SetActive(false);
        Time.timeScale = 1f;

        isPaused = true;

    }



}
