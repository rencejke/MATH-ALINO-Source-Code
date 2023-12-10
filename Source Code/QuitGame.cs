using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    [SerializeField] private GameObject quitGamePanel, pausePanel;
    [SerializeField] private ControlSound quitClickSound;
    [SerializeField] Button pauseButton2, backButton2, retryButton2, instructionsButton;

    [SerializeField] Button infoCreditsButton, tutorialButton;

    public void quitGame()
    {
        quitClickSound.SoundClick();
        quitGamePanel.SetActive(true);
        pausePanel.SetActive(false);

        //button will not clickable
        pauseButton2.interactable = false;
        backButton2.interactable = false;
        infoCreditsButton.interactable = false;
        tutorialButton.interactable = false;

        Time.timeScale = 0f;
    
    }
    public void yesQuit()
    {   
        quitClickSound.SoundClick();
        Application.Quit();
    }
    public void noQuit()
    {   
        quitClickSound.SoundClick();
        quitGamePanel.SetActive(false);
        pauseButton2.interactable = true;
        backButton2.interactable = true;
        retryButton2.interactable = true;
        instructionsButton.interactable = true;
        Time.timeScale = 1f;
    }

     public void noQuit2()//StartQuit
    {   
        quitClickSound.SoundClick();
        quitGamePanel.SetActive(false);

        infoCreditsButton.interactable = true;
        tutorialButton.interactable = true;

        Time.timeScale = 1f;
    }

}
