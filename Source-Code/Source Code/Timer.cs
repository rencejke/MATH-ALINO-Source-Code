using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] private Image UI_fillTimer;
    [SerializeField] private TextMeshProUGUI UI_textTimer;
    public GameObject timesOutPanel;
    public ControlSound timerSound;

    public int duration;
    private int remainingDuration;

    // Start is called before the first frame update
    private void Start()
    {
        Begin(duration);
    }

    private void Begin(int seconds)
    {
        remainingDuration = seconds;
        StartCoroutine(updateTimer());
    }

    private IEnumerator updateTimer()
    {
        while (remainingDuration >= 0)
        {
            UI_textTimer.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
            UI_fillTimer.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }

        onEnd();
    }

    private void onEnd()
    {
        timesOutPanel.SetActive(true);
        timerSound.GameOverSound();
        Time.timeScale = 0f;
    }

    // Method to add more seconds to the timer during runtime
    public void AddMoreSeconds(int secondsToAdd)
    {
        remainingDuration += secondsToAdd;
    }

    public void ReduceSeconds(int secondsToReduce)
    {
        remainingDuration -= secondsToReduce;
    }
}