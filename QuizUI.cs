 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizUI : MonoBehaviour
{   
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private TextMeshProUGUI questionText, scoreText;
    [SerializeField] private List<Image> lifeImageList;
    [SerializeField] private GameObject completeGamePanel, gameOverPanael, gameMenuPanel, mainMenuPanel;
    [SerializeField] private Image questionIamge;
    [SerializeField] private UnityEngine.Video.VideoPlayer questionVideo;
    [SerializeField] private AudioSource questionAudio;
    [SerializeField] private List<Button> options, mainMenuUIButtons;
    [SerializeField] private Color correctCol, wrongCol, normalCol, lifeReduceColor;
    

    private Question question; 
    private bool answered;
    private float audioLength;

    public TextMeshProUGUI ScoreText { get {return scoreText; } }

    public GameObject GameOverPanel { get {return gameOverPanael; } }
    public GameObject GameCompletePanel { get {return completeGamePanel; } }
    public GameObject GameMenuPanel { get {return gameMenuPanel; } }
    
    
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn)); 
        }

        for (int i = 0; i < mainMenuUIButtons.Count; i++)
        {
            Button localBtn = mainMenuUIButtons[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));  
        }
        
    }   

        public void SetQuestion(Question question)
        {
            this.question = question;

            switch (question.questionType)
            {
                case QuestionType.TEXT:
                     questionIamge.transform.parent.gameObject.SetActive(false);
                     break;

                case QuestionType.IMAGE:
                    ImageHolder();
                    questionIamge.transform.gameObject.SetActive(true);

                    questionIamge.sprite = question.qustionImg;
                    break;

                case QuestionType.VIDEO:
                    ImageHolder();
                    questionVideo.transform.gameObject.SetActive(true);

                    questionVideo.clip = question.qustionVideo;
                    questionVideo.Play();
                    break;

                case QuestionType.AUDIO:
                    ImageHolder();
                    questionAudio.transform.gameObject.SetActive(true);

                    audioLength = question.qustionClip.length;
                    StartCoroutine(PlayAudio());
                    break;
            }

            questionText.text = question.questionInfo;
            List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);

            for (int i = 0; i < options.Count; i++)
            {
                options[i].GetComponentInChildren<TextMeshProUGUI>().text = answerList[i];
                options[i].name = answerList[i];
                options[i].image.color = normalCol;
            }

            answered = false;
        }

        IEnumerator PlayAudio()
        {
            if (question.questionType == QuestionType.AUDIO)
            {
                questionAudio.PlayOneShot(question.qustionClip);

                yield return new WaitForSeconds(audioLength + 0.5f);

                StartCoroutine(PlayAudio());
            }
            else
            {
                StopCoroutine(PlayAudio());
            }
        }
        void ImageHolder()
        {
             questionIamge.transform.parent.gameObject.SetActive(true);
             questionIamge.transform.gameObject.SetActive(false);
             questionAudio.transform.gameObject.SetActive(false);
             questionVideo.transform.gameObject.SetActive(false);
        }


    private void OnClick(Button btn)
    {
        if (quizManager.GameStatus == GameStatus.Playing) 
        { 
            if(!answered)
            {
            answered = true;
            bool val = quizManager.Answer(btn.name);

            if(val)
            {
                btn.image.color = correctCol;
            }
            else
            {
                btn.image.color = wrongCol;
            }
         }   
        }

            switch (btn.name)  
            {
                case "Easy":
                     Debug.Log("Clicked");
                     quizManager.StartGame(0);
                     mainMenuPanel.SetActive(false);
                     gameMenuPanel.SetActive(true);
                break;

                case "Average":
                    quizManager.StartGame(1);
                    mainMenuPanel.SetActive(false);
                    gameMenuPanel.SetActive(true);
                break;

                case "Difficult":
                    quizManager.StartGame(2);
                    mainMenuPanel.SetActive(false);
                    gameMenuPanel.SetActive(true);
                break;
            }
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void reduceLife(int index)
    {
        lifeImageList[index].color = lifeReduceColor ;
    }
}
