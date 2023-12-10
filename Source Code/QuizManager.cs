using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{   
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private List<QuizDataScriptable> quizData;
   
    private List<Question> questions;
    private Question selectedQuestion;

    private GameStatus gameStatus = GameStatus.Next;

    public GameStatus GameStatus { get {return gameStatus; } }
    [SerializeField] private ControlSound controlSound;


    private int scoreCount = 0;
    private int lifeRemaining = 3;

    // Start is called before the first frame update
    public void StartGame(int index)
    {
        scoreCount = 0;
        lifeRemaining = 3;

         questions = new List<Question>();

        for (int i = 0; i < quizData[index].questions.Count; i++)
        {
              questions.Add(quizData[index].questions[i]);
        }

        SelectQuestion();
        gameStatus = GameStatus.Playing; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectQuestion()
    {
        int val = Random.Range(0, questions.Count);
        selectedQuestion = questions[val];

        quizUI.SetQuestion(selectedQuestion);
        questions.RemoveAt(val);
    }

    public bool Answer(string answered)
    {
        bool correctAns = false;

        if (answered == selectedQuestion.correctAns)
        {
            //correct
            controlSound.CorrectAnswer();
            correctAns = true;
            scoreCount += 20;
            quizUI.ScoreText.text = "Score: " +  scoreCount;
        }
        else
        {
            controlSound.WrongAnswer();
            lifeRemaining--;
            quizUI.reduceLife(lifeRemaining);

            if (lifeRemaining <= 0)
            {
                gameStatus = GameStatus.Next;
                StartCoroutine(ShowGameOverPanelDelayed());
                // quizUI.GameOverPanel.SetActive(true);
            }
        }
        
        if (gameStatus == GameStatus.Playing)
        {   
            if (questions.Count > 0)
            {   
                Invoke("SelectQuestion", 0.4f);   
            }
            else
            {
                gameStatus = GameStatus.Next;
                StartCoroutine(ShowGameCompletionPanel());
                // quizUI.GameCompletePanel.SetActive(true);
            }
             
        }
        return correctAns;
    }

     private IEnumerator ShowGameCompletionPanel()
    {
        // Wait for a delay before showing the game completion panel
        yield return new WaitForSeconds(0.30f); //delay in seconds
       ShowCompletePanel();
    }

    public void ShowCompletePanel()
    {
         quizUI.GameCompletePanel.SetActive(true);
         controlSound.gameCompleteSound();
    }

     private IEnumerator ShowGameOverPanelDelayed()
    {
        // Wait for a delay before showing the game over panel
        yield return new WaitForSeconds(0.3f); //delay in seconds
        ShowGameOverPanel();
    }

    public void ShowGameOverPanel()
    {
        quizUI.GameOverPanel.SetActive(true);
        controlSound.GameOverSound();  

    //     if (playersLife.lifeLeft <= 0)
    // {
    //     // Disable the buttons if the player's life is zero or less
    //     go_backButton.interactable = false;
    //     go_pauseButton.interactable = false;
    //     go_retryButton.interactable = false;
    // }
    
    }   
    
}
[System.Serializable]
    public class Question
    {
        public string questionInfo;
        public QuestionType questionType;
        public Sprite qustionImg;
        public AudioClip qustionClip;
        public UnityEngine.Video.VideoClip qustionVideo;
        public List<string> options;
        public string correctAns;
    }

    [System.Serializable]
    public enum QuestionType
    {
        TEXT,
        IMAGE, 
        VIDEO,
        AUDIO
    }
    [System.Serializable]
    public enum GameStatus
    {
        Next,
        Playing
    }

