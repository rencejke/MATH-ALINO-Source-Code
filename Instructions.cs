using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    [SerializeField] private GameObject instructionPanel;
    [SerializeField] private ControlSound instctClickSound;
    [SerializeField] Button pauseButton, backButton, retryButton, instructionButton;

    private float delay = 0.3f; // The delay in seconds before changing Time.timeScale

    public void instructionClick()
    {
        instctClickSound.SoundClick();
        instructionPanel.SetActive(true);

        // Buttons will not be clickable immediately
        pauseButton.interactable = false;
        backButton.interactable = false;
        retryButton.interactable = false;
        instructionButton.interactable = false;

        StartCoroutine(ChangeTimeScale(0f, delay)); // Set Time.timeScale to 0 after the delay
    }

    public void closeInstructionPanel()
    {
        instctClickSound.SoundClick();

        // Buttons will not be clickable immediately
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
