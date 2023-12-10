using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuPanel;
    [SerializeField] Button pauseButton, backButton, retryButton, instructionButton;
    
    private float delay = 0.7f;
    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        pauseButton.interactable = false;
        backButton.interactable = false;
        retryButton.interactable = false;
        instructionButton.interactable = false;
        
         StartCoroutine(ChangeTimeScale(0f, delay));
    }
    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        pauseButton.interactable = true;
        backButton.interactable = true;
        retryButton.interactable = true;
        instructionButton.interactable = true;
        Time.timeScale = 1f;  
    }

    private IEnumerator ChangeTimeScale(float targetTimeScale, float delay)
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = targetTimeScale;
    }
}
