using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public static class scoreChallengeManager
{
    public static int score;
}

public class DragAndDropChallenge : MonoBehaviour
{
    public GameObject[] answer;
    Vector2[] answerFirstPos;
    public GameObject dropAnswer;

    public int dropDistance;

    //reference from other script
    public GenerateQuestion genQuest;
    public ControlSound challengeSound;
    public PlayerLife challengeLife;
    public Timer timer;
    public TextMeshProUGUI scoreChallengeText;
    // public UpdateScoreInOtherGamePanel otherPanelUpdater;

    //dialogs
    public GameObject correctDialog, wrongDialog;

    //panels
    public GameObject gameOverPanel, timesOutPanel;
    
    public Button pauseButton, backButton, retryButton, instructionsButton;

    private void Awake()
    {
        scoreChallengeText.text =  scoreChallengeManager.score.ToString();

        // Update the score in the other game panel when the game starts
        // otherPanelUpdater.UpdateScore(scoreChallengeManager.score);
    }

    void Start()
    {
        answerFirstPos = new Vector2[answer.Length];
        for (int i = 0; i < answer.Length; i++)
        {
            answerFirstPos[i] = answer[i].transform.localPosition;
        }

        challengeLife.lifeLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DragAnswer(int number)
    {
        answer[number].transform.position = Input.mousePosition;
        
        answer[number].GetComponent<Canvas>().sortingOrder = 1;
    }

    public void EndDragAnswer(int number)
    {
        float distance = Vector3.Distance(answer[number].transform.localPosition, dropAnswer.transform.localPosition);

        if (distance < dropDistance)
        {
            answer[number].transform.localPosition = dropAnswer.transform.localPosition;

            if (genQuest.rightAnswer == int.Parse(answer[number].transform.GetChild(0).GetComponent<TMP_Text>().text))
            {   
                scoreChallengeManager.score +=20;
                scoreChallengeText.text =  scoreChallengeManager.score.ToString();
                Debug.Log("Correct");
                challengeSound.CorrectAnswer();
                ActivateCorrectForDuration();
                timer.AddMoreSeconds(10);
               
            }
            else
            {
                Debug.Log("Wrong");
                challengeSound.WrongAnswer();
                challengeLife.lifeLeft--;
                ActivateWrongForDuration();
                timer.ReduceSeconds(2);
                challengeLife.LifeReduce(challengeLife.lifeLeft);
            }

            if (challengeLife.lifeLeft == 0)
            {   
                ActivateGameOverPanelForDuration();
                ActivateGameOverSound();
            }

            /*
            genQuest.Question();
            for (int i = 0; i < answer.Length; i++)
            {
                answer[i].transform.localPosition = answerFirstPos[i];
            }*/

            for (int i = 0; i < answer.Length; i++)
            {   
                answer[i].GetComponent<GraphicRaycaster>().enabled = false;
            }

            Invoke("DelayNextQuest", 1f); 
        }
        else
        {
            answer[number].transform.localPosition = answerFirstPos[number];

            answer[number].GetComponent<Canvas>().sortingOrder = 0;
        }
    }

    void DelayNextQuest()
    {
        genQuest.Question();
        for (int i = 0; i < answer.Length; i++)
        {
            answer[i].transform.localPosition = answerFirstPos[i];

            answer[i].GetComponent<GraphicRaycaster>().enabled = true;
        }
    }


    public void ActivateGameOverPanelForDuration()
    {
        StartCoroutine(ActivateGameOverPanelCoroutine());
    }

    private IEnumerator ActivateGameOverPanelCoroutine()
    {
        yield return new WaitForSeconds(1.5f); 
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

     public void ActivateGameOverSound()
    {
        StartCoroutine(ActivateGameOverSoundCoroutine());
    }

    private IEnumerator ActivateGameOverSoundCoroutine()
    {
        yield return new WaitForSeconds(1.5f); 
        challengeSound.GameOverSound();
        
    }


     public void ActivateCorrectForDuration()
    {
        StartCoroutine(ActivateCorrectCoroutine());
    }

    private IEnumerator ActivateCorrectCoroutine()
    {
        correctDialog.SetActive(true);
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        correctDialog.SetActive(false);
    }
   

    public void ActivateWrongForDuration()
    {
        StartCoroutine(ActivateWrongCoroutine());
    }

    private IEnumerator ActivateWrongCoroutine()
    {
        wrongDialog.SetActive(true);
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        wrongDialog.SetActive(false);
    }

    public UnityEngine.SceneManagement.Scene GetActiveScene()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }

    //  void UpdateScoreInOtherPanel(int newScore)
    // {
    //     otherPanelUpdater.UpdateScore(newScore);
    // }

    public void RetryButtonChallenge()
    {
        // if (SceneManager.GetActiveScene().name == "ChallengeSelection")
        // {
        //     // Reset the score to zero for the specific scene
        //     scoreChallengeManager.score = 0;
        // }
        // else if (SceneManager.GetActiveScene().name == "2_ChallengeSelection")
        // {
        //     scoreChallengeManager.score = 0;
        // }
        // else if (SceneManager.GetActiveScene().name == "3_ChallengeSelection")
        // {
        //     scoreChallengeManager.score = 0;
        // }

        UnityEngine.SceneManagement.SceneManager.LoadScene(GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        scoreChallengeManager.score = 0;
    }

}
