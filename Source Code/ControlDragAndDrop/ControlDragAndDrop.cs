using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ControlDragAndDrop : MonoBehaviour
{
    public GameObject answer, answer2, answer3; //options
    Vector2 answerFirstPos, answer2FirstPos, answer3FirstPos; // Position variables for initial positions
    public GameObject dropAnswerSlot, dropAnswerSlot2, dropAnswerSlot3; // Third slot added
    public int dropDistance, dropDistance2, dropDistance3; // Drop distances for all options

    [SerializeField] private GameObject gameCompletePanel, gameOverPanel;
    [SerializeField] Button go_pauseButton, go_backButton, go_retryButton;

    [SerializeField] private ControlSound controlSound;
    [SerializeField] private PlayerLife playersLife;
    [SerializeField] private PauseGame pauseGame;

    private bool answer1Correct = false;
    private bool answer2Correct = false;
    private bool answer3Correct = false; 

    //add
    private static List<int> loadedScenes2 = new List<int>();
     private static int lastLoadedSceneIndex2 = -1; 

      //subtract
     private static List<int> loadedScenesSub = new List<int>();
     private static int lastLoadedSceneIndexSub = -1; 
    

    //event triggers
     private EventTrigger answerEventTrigger, answer2EventTrigger, answer3EventTrigger;

    void Start()
    {
        // Save initial positions
        answerFirstPos = answer.transform.localPosition;
        answer2FirstPos = answer2.transform.localPosition;
        answer3FirstPos = answer3.transform.localPosition;

        answerEventTrigger = answer.GetComponent<EventTrigger>();
        answer2EventTrigger = answer2.GetComponent<EventTrigger>();
        answer3EventTrigger = answer3.GetComponent<EventTrigger>();


        playersLife.lifeLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DragAnswer()
    {
        answer.transform.position = Input.mousePosition;
    }

    public void EndDragAnswer()
    {
        float distance = Vector3.Distance(answer.transform.localPosition, dropAnswerSlot.transform.localPosition);

        if (distance < dropDistance)
        {
            answer.transform.localPosition = dropAnswerSlot.transform.localPosition;
            controlSound.CorrectAnswer();
            answer1Correct = true; // Set the answer1Correct flag to true
            MakeAnswerNotDraggable(answerEventTrigger); // Disable dragging for this answer
        }
        else
        {
            answer.transform.localPosition = answerFirstPos;
            Debug.Log("Not");
            controlSound.WrongAnswer();
            playersLife.lifeLeft--;
            playersLife.LifeReduce(playersLife.lifeLeft);
        }

        CheckCorrectness();
    }

    public void DragAnswer2()
    {
        answer2.transform.position = Input.mousePosition;
    }

    public void EndDragAnswer2()
    {
        float distance2 = Vector3.Distance(answer2.transform.localPosition, dropAnswerSlot2.transform.localPosition);
        
        if (distance2 < dropDistance2)
        {
            answer2.transform.localPosition = dropAnswerSlot2.transform.localPosition;
            Debug.Log("Stick");
            controlSound.CorrectAnswer();
            answer2Correct = true; // Set the answer1Correct flag to true
            MakeAnswerNotDraggable(answer2EventTrigger); // Disable dragging for this answer
        }
        else
        {
            answer2.transform.localPosition = answer2FirstPos;
            Debug.Log("Not");
            controlSound.WrongAnswer();
            playersLife.lifeLeft--;
            playersLife.LifeReduce(playersLife.lifeLeft);
        }

        CheckCorrectness();
    }

    public void DragAnswer3() // New method for dragging the third option
    {
        answer3.transform.position = Input.mousePosition;
    }

    public void EndDragAnswer3() // New method for ending drag for the third option
    {
        float distance3 = Vector3.Distance(answer3.transform.localPosition, dropAnswerSlot3.transform.localPosition);

        if (distance3 < dropDistance3)
        {
            answer3.transform.localPosition = dropAnswerSlot3.transform.localPosition;
            Debug.Log("Stick");
            controlSound.CorrectAnswer();
            answer3Correct = true; // Set the answer1Correct flag to true
            MakeAnswerNotDraggable(answer3EventTrigger); // Disable dragging for this answer
        }
        else
        {
            answer3.transform.localPosition = answer3FirstPos;
            Debug.Log("Not");
            controlSound.WrongAnswer();

            playersLife.lifeLeft--;
            playersLife.LifeReduce(playersLife.lifeLeft);
        }

        CheckCorrectness();
    }


    private void CheckCorrectness()
    {
        // Check if all three answers are in their respective slots
        bool answer1Correct = Vector3.Distance(answer.transform.localPosition, dropAnswerSlot.transform.localPosition) < dropDistance;
        bool answer2Correct = Vector3.Distance(answer2.transform.localPosition, dropAnswerSlot2.transform.localPosition) < dropDistance2;
        bool answer3Correct = Vector3.Distance(answer3.transform.localPosition, dropAnswerSlot3.transform.localPosition) < dropDistance3;


         if ((answer1Correct && answer2Correct) || (answer1Correct && answer3Correct) || (answer2Correct && answer1Correct)
        || (answer2Correct && answer3Correct) || (answer3Correct && answer1Correct))
        {
          controlSound.gameCompleteSound();
          StartCoroutine(ShowGameCompletionPanel());
        }

        else if (playersLife.lifeLeft <= 0)
        {
            StartCoroutine(ShowGameOverPanelDelayed());
            
        }
    }
    
    private void MakeAnswerNotDraggable(EventTrigger eventTrigger)
    {
        eventTrigger.enabled = false;
    }

    private void MakeButtonNotClickable(EventTrigger eventClick)
    {
        eventClick.enabled = false;
    }

    private IEnumerator ShowGameCompletionPanel()
    {
        // Wait for a delay before showing the game completion panel
        yield return new WaitForSeconds(0.30f); //delay in seconds
        gameCompletePanel.SetActive(true);
    }

    private IEnumerator ShowGameOverPanelDelayed()
    {
        // Wait for a delay before showing the game over panel
        yield return new WaitForSeconds(0.3f); //delay in seconds
        ShowGameOverPanel();
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        controlSound.GameOverSound();  

        if (playersLife.lifeLeft <= 0)
    {
        // Disable the buttons if the player's life is zero or less
        go_backButton.interactable = false;
        go_pauseButton.interactable = false;
        go_retryButton.interactable = false;
    }
    
    }   

    public void loadRandomScenes()
    {
        List<int> sceneIndices2 = new List<int> { 7, 8, 9, 10 };
        int specificSceneIndex2 = 21;
        
        if (loadedScenes2.Count >= sceneIndices2.Count)
        {
            // All scenes have been loaded, show game over panel
             SceneManager.LoadScene(specificSceneIndex2);
            return;
        }

        sceneIndices2.RemoveAll(index => loadedScenes2.Contains(index));
        sceneIndices2.Remove(lastLoadedSceneIndex2); // Exclude the previous scene index

        int randomIndex2 = Random.Range(0, sceneIndices2.Count);
        int sceneIndex2 = sceneIndices2[randomIndex2];

        loadedScenes2.Add(sceneIndex2);
        lastLoadedSceneIndex2 = sceneIndex2; // Update the last loaded scene index
        SceneManager.LoadScene(sceneIndex2);
    }

     public void loadRandomScenesSub()
    {
        List<int> sceneIndicesSub = new List<int> { 12, 13, 14, 15 };
        int specificSceneIndexSub = 21;
        
        if (loadedScenesSub.Count >= sceneIndicesSub.Count)
        {
            // All scenes have been loaded, show game over panel
             SceneManager.LoadScene(specificSceneIndexSub);
            return;
        }

        sceneIndicesSub.RemoveAll(index => loadedScenesSub.Contains(index));
        sceneIndicesSub.Remove(lastLoadedSceneIndexSub); // Exclude the previous scene index

        int randomIndexSub = Random.Range(0, sceneIndicesSub.Count);
        int sceneIndexSub = sceneIndicesSub[randomIndexSub];

        loadedScenesSub.Add(sceneIndexSub);
        lastLoadedSceneIndexSub = sceneIndexSub; // Update the last loaded scene index
        SceneManager.LoadScene(sceneIndexSub);
    }


}
