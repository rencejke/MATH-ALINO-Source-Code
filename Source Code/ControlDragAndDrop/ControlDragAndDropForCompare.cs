using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ControlDragAndDropForCompare : MonoBehaviour
{
    public GameObject answerCompare, answer2Compare, answer3Compare; //options
    Vector2 answerPos1, answer2Pos1, answer3Pos1; // Position variables for initial positions
    public GameObject dropAnswerSlotCompare, dropAnswerSlot2Compare, dropAnswerSlot3Compare; // Third slot added
    public int dropDistanceCompare, dropDistance2Compare, dropDistance3Compare; // Drop distances for all options

    [SerializeField] private GameObject gameCompletePanelForCompare, gameOverPanelForCompare;
    [SerializeField] Button go_pauseButtonCompare, go_backButtonCompare, go_retryButtonCompare;

    [SerializeField] private ControlSound controlSoundCompare;
    [SerializeField] private PlayerLife playersLifeCompare;
    [SerializeField] private PauseGame pauseGameCompare;

    private bool answer1CorrectCompare = false;
    private bool answer2CorrectCompare = false;
    private bool answer3CorrectCompare = false; 
    
    //compare
     private static List<int> loadedScenes = new List<int>();
     private static int lastLoadedSceneIndex = -1; 
    
   
    //event triggers
     private EventTrigger answerEventTriggerCompare, answer2EventTriggerCompare, answer3EventTriggerCompare;

    void Start()
    {
        // Save initial positions
        answerPos1 = answerCompare.transform.localPosition;
        answer2Pos1 = answer2Compare.transform.localPosition;
        answer3Pos1 = answer3Compare.transform.localPosition;

        answerEventTriggerCompare = answerCompare.GetComponent<EventTrigger>();
        answer2EventTriggerCompare = answer2Compare.GetComponent<EventTrigger>();
        answer3EventTriggerCompare = answer3Compare.GetComponent<EventTrigger>();


        playersLifeCompare.lifeLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DragAnswer()
    {
        answerCompare.transform.position = Input.mousePosition;
    }

    public void EndDragAnswer()
    {
        float distance = Vector3.Distance(answerCompare.transform.localPosition, dropAnswerSlotCompare.transform.localPosition);

        if (distance < dropDistanceCompare)
        {
            answerCompare.transform.localPosition = dropAnswerSlotCompare.transform.localPosition;
            controlSoundCompare.CorrectAnswer();
            answer1CorrectCompare = true; // Set the answer1Correct flag to true
            MakeAnswerNotDraggable(answerEventTriggerCompare); // Disable dragging for this answer
        }
        else
        {
            answerCompare.transform.localPosition = answerPos1;
            controlSoundCompare.WrongAnswer();
            playersLifeCompare.lifeLeft--;
            playersLifeCompare.LifeReduce(playersLifeCompare.lifeLeft);
        }

        CheckCorrectness();
    }

    public void DragAnswer2()
    {
        answer2Compare.transform.position = Input.mousePosition;
    }

    public void EndDragAnswer2()
    {
        float distance2 = Vector3.Distance(answer2Compare.transform.localPosition, dropAnswerSlot2Compare.transform.localPosition);
        
        if (distance2 < dropDistance2Compare)
        {
            answer2Compare.transform.localPosition = dropAnswerSlot2Compare.transform.localPosition;
            controlSoundCompare.CorrectAnswer();
            answer2CorrectCompare = true; // Set the answer1CorrectCompare flag to true
            MakeAnswerNotDraggable(answer2EventTriggerCompare); // Disable dragging for this answer
        }
        else
        {
            answer2Compare.transform.localPosition = answer2Pos1;
            controlSoundCompare.WrongAnswer();
            playersLifeCompare.lifeLeft--;
            playersLifeCompare.LifeReduce(playersLifeCompare.lifeLeft);
        }

        CheckCorrectness();
    }

    public void DragAnswer3() // New method for dragging the third option
    {
        answer3Compare.transform.position = Input.mousePosition;
    }

    public void EndDragAnswer3() // New method for ending drag for the third option
    {
        float distance3 = Vector3.Distance(answer3Compare.transform.localPosition, dropAnswerSlot3Compare.transform.localPosition);

        if (distance3 < dropDistance3Compare)
        {
            answer3Compare.transform.localPosition = dropAnswerSlot3Compare.transform.localPosition;
            controlSoundCompare.CorrectAnswer();
            answer3CorrectCompare = true; // Set the answer1CorrectCompare flag to true
            MakeAnswerNotDraggable(answer3EventTriggerCompare); // Disable dragging for this answer
        }
        else
        {
            answer3Compare.transform.localPosition = answer3Pos1;
            controlSoundCompare.WrongAnswer();
            playersLifeCompare.lifeLeft--;
            playersLifeCompare.LifeReduce(playersLifeCompare.lifeLeft);
        }

        CheckCorrectness();
    }


    private void CheckCorrectness()
    {
        // Check if all three answers are in their respective slots
        bool answer1CorrectCompare = Vector3.Distance(answerCompare.transform.localPosition, dropAnswerSlotCompare.transform.localPosition) < dropDistanceCompare;
        bool answer2CorrectCompare = Vector3.Distance(answer2Compare.transform.localPosition, dropAnswerSlot2Compare.transform.localPosition) < dropDistance2Compare;
        bool answer3CorrectCompare = Vector3.Distance(answer3Compare.transform.localPosition, dropAnswerSlot3Compare.transform.localPosition) < dropDistance3Compare;


         if ((answer1CorrectCompare) || (answer2CorrectCompare) || (answer3CorrectCompare))
        {
          controlSoundCompare.gameCompleteSound();
          StartCoroutine(ShowGameCompletionPanel());
        }

        else if (playersLifeCompare.lifeLeft <= 0)
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
        gameCompletePanelForCompare.SetActive(true);
    }

    private IEnumerator ShowGameOverPanelDelayed()
    {
        // Wait for a delay before showing the game over panel
        yield return new WaitForSeconds(0.3f); //delay in seconds
        ShowGameOverPanel();
    }

    public void ShowGameOverPanel()
    {
        gameOverPanelForCompare.SetActive(true);
        controlSoundCompare.GameOverSound();  

        if (playersLifeCompare.lifeLeft <= 0)
    {
        // Disable the buttons if the player's life is zero or less
        go_backButtonCompare.interactable = false;
        go_pauseButtonCompare.interactable = false;
        go_retryButtonCompare.interactable = false;
    }
    
}
    public void loadRandomScenes()
    {
        List<int> sceneIndices = new List<int> { 17, 18, 19, 20 };
        int specificSceneIndex = 21;
        
        if (loadedScenes.Count >= sceneIndices.Count)
        {
            // All scenes have been loaded, show game over panel
             SceneManager.LoadScene(specificSceneIndex);
            return;
        }

        sceneIndices.RemoveAll(index => loadedScenes.Contains(index));
        sceneIndices.Remove(lastLoadedSceneIndex); // Exclude the previous scene index

        int randomIndex = Random.Range(0, sceneIndices.Count);
        int sceneIndex = sceneIndices[randomIndex];

        loadedScenes.Add(sceneIndex);
        lastLoadedSceneIndex = sceneIndex; // Update the last loaded scene index
        SceneManager.LoadScene(sceneIndex);
    }

   
}

