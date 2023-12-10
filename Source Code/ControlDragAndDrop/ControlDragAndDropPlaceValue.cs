// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;
// using UnityEngine.SceneManagement;


// public class ControlDragAndDropPlaceValue : MonoBehaviour
// {
//     public GameObject answer, answer2, answer3, answer4, answer5; //options
//     Vector2 answerFirstPos, answer2FirstPos, answer3FirstPos, answer4FirstPos, answer5FirstPos; // Position variables for initial positions
//     public GameObject dropAnswerSlot, dropAnswerSlot2, dropAnswerSlot3, dropAnswerSlot4, dropAnswerSlot5; //4th and 5th slot added
//     public int dropDistance, dropDistance2, dropDistance3, dropDistance4; // Drop distances for all options

//     [SerializeField] private GameObject gameCompletePanel, gameOverPanel;
//     [SerializeField] Button go_pauseButton, go_backButton, go_retryButton;

//     [SerializeField] private ControlSound soundControl;
//     [SerializeField] private PlayerLife playersLifeValue;
//     [SerializeField] private PauseGame pauseStatus;

//     private bool answer1Correct = false;
//     private bool answer2Correct = false;
//     private bool answer3Correct = false; 
//     private bool answer4Correct = false; 
//     private bool answer5Correct = false;

//     //add
//     private static List<int> loadedScenes2 = new List<int>();
//     private static int lastLoadedSceneIndex2 = -1; 

//     //subtract
//      private static List<int> loadedScenesSub = new List<int>();
//      private static int lastLoadedSceneIndexSub = -1; 
    

//     //event triggers
//      private EventTrigger answerEventTrigger, answer2EventTrigger, answer3EventTrigger, answer4EventTrigger, answer5EventTrigger;

//     void Start()
//     {
//         // Save initial positions
//         answerFirstPos = answer.transform.localPosition;
//         answer2FirstPos = answer2.transform.localPosition;
//         answer3FirstPos = answer3.transform.localPosition;
//         answer4FirstPos = answer4.transform.localPosition;
//         answer5FirstPos = answer5.transform.localPosition;

//         answerEventTrigger = answer.GetComponent<EventTrigger>();
//         answer2EventTrigger = answer2.GetComponent<EventTrigger>();
//         answer3EventTrigger = answer3.GetComponent<EventTrigger>();
//         answer4EventTrigger = answer4.GetComponent<EventTrigger>();
//         answer5EventTrigger = answer5.GetComponent<EventTrigger>();


//         playersLifeValue.lifeLeft = 3;
//     }

//     // Update is called once per frame
//     void Update()
//     {
       
//     }

//     public void DragAnswer()
//     {
//         answer.transform.position = Input.mousePosition;
//     }

//     public void EndDragAnswer()
//     {
//         float distance = Vector3.Distance(answer.transform.localPosition, dropAnswerSlot.transform.localPosition);

//         if (distance < dropDistance)
//         {
//             answer.transform.localPosition = dropAnswerSlot.transform.localPosition;
//             soundControl.CorrectAnswer();
//             answer1Correct = true; // Set the answer1Correct flag to true
//             MakeAnswerNotDraggable(answerEventTrigger); // Disable dragging for this answer
//         }
//         else
//         {
//             answer.transform.localPosition = answerFirstPos;
//             Debug.Log("Not");
//             soundControl.WrongAnswer();
//             playersLifeValue.lifeLeft--;
//             playersLifeValue.LifeReduce(playersLifeValue.lifeLeft);
//         }

//         CheckCorrectness();
//     }

//     public void DragAnswer2()
//     {
//         answer2.transform.position = Input.mousePosition;
//     }

//     public void EndDragAnswer2()
//     {
//         float distance2 = Vector3.Distance(answer2.transform.localPosition, dropAnswerSlot2.transform.localPosition);
        
//         if (distance2 < dropDistance2)
//         {
//             answer2.transform.localPosition = dropAnswerSlot2.transform.localPosition;
//             Debug.Log("Stick");
//             soundControl.CorrectAnswer();
//             answer2Correct = true; // Set the answer1Correct flag to true
//             MakeAnswerNotDraggable(answer2EventTrigger); // Disable dragging for this answer
//         }
//         else
//         {
//             answer2.transform.localPosition = answer2FirstPos;
//             Debug.Log("Not");
//             soundControl.WrongAnswer();
//             playersLifeValue.lifeLeft--;
//             playersLifeValue.LifeReduce(playersLifeValue.lifeLeft);
//         }

//         CheckCorrectness();
//     }

//     public void DragAnswer3() 
//     {
//         answer3.transform.position = Input.mousePosition;
//     }

//     public void EndDragAnswer3()
//     {
//         float distance3 = Vector3.Distance(answer3.transform.localPosition, dropAnswerSlot3.transform.localPosition);

//         if (distance3 < dropDistance3)
//         {
//             answer3.transform.localPosition = dropAnswerSlot3.transform.localPosition;
//             Debug.Log("Stick");
//             soundControl.CorrectAnswer();
//             answer3Correct = true; // Set the answer1Correct flag to true
//             MakeAnswerNotDraggable(answer3EventTrigger); // Disable dragging for this answer
//         }
//         else
//         {
//             answer3.transform.localPosition = answer3FirstPos;
//             Debug.Log("Not");
//             soundControl.WrongAnswer();
//             playersLifeValue.lifeLeft--;
//             playersLifeValue.LifeReduce(playersLifeValue.lifeLeft);
//         }

//         CheckCorrectness();
//     }

//     public void DragAnswer4()
//     {
//         answer4.transform.position = Input.mousePosition;
//     }

//     public void EndDragAnswer4()
//     {
//         float distance4 = Vector3.Distance(answer4.transform.localPosition, dropAnswerSlot4.transform.localPosition);

//         if (distance4 < dropDistance4)
//         {
//             answer4.transform.localPosition = dropAnswerSlot4.transform.localPosition;
//             soundControl.CorrectAnswer();
//             answer4Correct = true; 
//             MakeAnswerNotDraggable(answerEventTrigger); 
//         }
//         else
//         {
//             answer4.transform.localPosition = answer4FirstPos;
//             soundControl.WrongAnswer();
//             playersLifeValue.lifeLeft--;
//             playersLifeValue.LifeReduce(playersLifeValue.lifeLeft);
//         }

//         CheckCorrectness();
//     }

//      public void DragAnswer5()
//     {
//         answer5.transform.position = Input.mousePosition;
//     }

//     public void EndDragAnswer5()
//     {
//         float distance5 = Vector3.Distance(answer5.transform.localPosition, dropAnswerSlot5.transform.localPosition);

//         if (distance5 < dropDistance5)
//         {
//             answer5.transform.localPosition = dropAnswerSlot5.transform.localPosition;
//             soundControl.CorrectAnswer();
//             answer5Correct = true; 
//             MakeAnswerNotDraggable(answerEventTrigger); 
//         }
//         else
//         {
//             answer5.transform.localPosition = answer5FirstPos;
//             soundControl.WrongAnswer();
//             playersLifeValue.lifeLeft--;
//             playersLifeValue.LifeReduce(playersLifeValue.lifeLeft);
//         }

//         CheckCorrectness();
//     }

//     private void CheckCorrectness()
//     {
//         // Check if all three answers are in their respective slots
//         bool answer1Correct = Vector3.Distance(answer.transform.localPosition, dropAnswerSlot.transform.localPosition) < dropDistance;

//         bool answer2Correct = Vector3.Distance(answer2.transform.localPosition, dropAnswerSlot2.transform.localPosition) < dropDistance2;

//         bool answer3Correct = Vector3.Distance(answer3.transform.localPosition, dropAnswerSlot3.transform.localPosition) < dropDistance3;

//         bool answer4Correct = Vector3.Distance(answer3.transform.localPosition, dropAnswerSlot3.transform.localPosition) < dropDistance4;

//         bool answer5Correct = Vector3.Distance(answer5.transform.localPosition, dropAnswerSlot5.transform.localPosition) < dropDistance5;


//          if ((answer1Correct && answer2Correct && answer3Correct) || (answer1Correct && answer2Correct && answer4Correct) || (answer1Correct && answer2Correct && answer5Correct)  || (answer1Correct && answer3Correct && answer4Correct) || (answer1Correct && answer2Correct && answer5Correct) || (answer1Correct && answer4Correct && answer5Correct) || 
//          (answer2Correct && answer3Correct && answer4Correct) || (answer2Correct && answer3Correct && answer5Correct) 
//          (answer2Correct && answer4Correct && answer5Correct) || (answer3Correct && answer4Correct && answer5Correct))
//         {
//           soundControl.gameCompleteSound();
//           StartCoroutine(ShowGameCompletionPanel());
//         }

//         else if (playersLifeValue.lifeLeft <= 0)
//         {
//             StartCoroutine(ShowGameOverPanelDelayed());
            
//         }
//     }
    
//     private void MakeAnswerNotDraggable(EventTrigger eventTrigger)
//     {
//         eventTrigger.enabled = false;
//     }

//     private void MakeButtonNotClickable(EventTrigger eventClick)
//     {
//         eventClick.enabled = false;
//     }

//     private IEnumerator ShowGameCompletionPanel()
//     {
//         // Wait for a delay before showing the game completion panel
//         yield return new WaitForSeconds(0.30f); //delay in seconds
//         gameCompletePanel.SetActive(true);
//     }

//     private IEnumerator ShowGameOverPanelDelayed()
//     {
//         // Wait for a delay before showing the game over panel
//         yield return new WaitForSeconds(0.3f); //delay in seconds
//         ShowGameOverPanel();
//     }

//     public void ShowGameOverPanel()
//     {
//         gameOverPanel.SetActive(true);
//         soundControl.GameOverSound();  

//         if (playersLifeValue.lifeLeft <= 0)
//     {
//         // Disable the buttons if the player's life is zero or less
//         go_backButton.interactable = false;
//         go_pauseButton.interactable = false;
//         go_retryButton.interactable = false;
//     }
    
//     }   

//     public void loadRandomScenes()
//     {
//         List<int> sceneIndices2 = new List<int> { 7, 8, 9, 10 };
//         int specificSceneIndex2 = 21;
        
//         if (loadedScenes2.Count >= sceneIndices2.Count)
//         {
//             // All scenes have been loaded, show game over panel
//              SceneManager.LoadScene(specificSceneIndex2);
//             return;
//         }

//         sceneIndices2.RemoveAll(index => loadedScenes2.Contains(index));
//         sceneIndices2.Remove(lastLoadedSceneIndex2); // Exclude the previous scene index

//         int randomIndex2 = Random.Range(0, sceneIndices2.Count);
//         int sceneIndex2 = sceneIndices2[randomIndex2];

//         loadedScenes2.Add(sceneIndex2);
//         lastLoadedSceneIndex2 = sceneIndex2; // Update the last loaded scene index
//         SceneManager.LoadScene(sceneIndex2);
//     }

//      public void loadRandomScenesSub()
//     {
//         List<int> sceneIndicesSub = new List<int> { 12, 13, 14, 15 };
//         int specificSceneIndexSub = 21;
        
//         if (loadedScenesSub.Count >= sceneIndicesSub.Count)
//         {
//             // All scenes have been loaded, show game over panel
//              SceneManager.LoadScene(specificSceneIndexSub);
//             return;
//         }

//         sceneIndicesSub.RemoveAll(index => loadedScenesSub.Contains(index));
//         sceneIndicesSub.Remove(lastLoadedSceneIndexSub); // Exclude the previous scene index

//         int randomIndexSub = Random.Range(0, sceneIndicesSub.Count);
//         int sceneIndexSub = sceneIndicesSub[randomIndexSub];

//         loadedScenesSub.Add(sceneIndexSub);
//         lastLoadedSceneIndexSub = sceneIndexSub; // Update the last loaded scene index
//         SceneManager.LoadScene(sceneIndexSub);
//     }


// }

//experiment

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ControlDragAndDropPlaceValue : MonoBehaviour
{
    [Header("Options")]
    public GameObject[] answers; // Options
    private Vector2[] answerFirstPositions; // Position variables for initial positions

    [Header("Drop Slots")]
    public GameObject[] dropAnswerSlots; // Drop slots for options
    public int[] dropDistances; // Drop distances for all options

    [Header("UI Panels and Buttons")]
    [SerializeField] private GameObject gameCompletePanel, gameOverPanel;
    [SerializeField] private Button go_pauseButton, go_backButton, go_retryButton, go_instruction;

    [Header("Game Components")]
    [SerializeField] private ControlSound soundControl;
    [SerializeField] private PlayerLife playersLifeValue;
    [SerializeField] private PauseGame pauseStatus;

    private List<int> loadedScenes2 = new List<int>();
    private int lastLoadedSceneIndex2 = -1;

    private List<int> loadedScenesSub = new List<int>();
    private int lastLoadedSceneIndexSub = -1;

    private bool[] answerCorrectFlags; // Flags to track correctness for each answer

    private void Start()
    {
        // Save initial positions
        answerFirstPositions = new Vector2[answers.Length];
        for (int i = 0; i < answers.Length; i++)
        {
            answerFirstPositions[i] = answers[i].transform.localPosition;
        }

        // Initialize answer correctness flags
        answerCorrectFlags = new bool[answers.Length];

        // Get EventTriggers for answers
        EventTrigger[] answerEventTriggers = new EventTrigger[answers.Length];
        for (int i = 0; i < answers.Length; i++)
        {
            answerEventTriggers[i] = answers[i].GetComponent<EventTrigger>();
        }

        playersLifeValue.lifeLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic here (if any)
    }

    public void DragAnswer(int answerIndex)
    {
        answers[answerIndex].transform.position = Input.mousePosition;
    }

    public void EndDragAnswer(int answerIndex)
    {
        float distance = Vector3.Distance(answers[answerIndex].transform.localPosition, dropAnswerSlots[answerIndex].transform.localPosition);

        if (distance < dropDistances[answerIndex])
        {
            answers[answerIndex].transform.localPosition = dropAnswerSlots[answerIndex].transform.localPosition;
            soundControl.CorrectAnswer();
            answerCorrectFlags[answerIndex] = true; // Set the answerCorrectFlags flag to true
            MakeAnswerNotDraggable(answerIndex); // Disable dragging for this answer
        }
        else
        {
            answers[answerIndex].transform.localPosition = answerFirstPositions[answerIndex];
            soundControl.WrongAnswer();
            playersLifeValue.lifeLeft--;
            playersLifeValue.LifeReduce(playersLifeValue.lifeLeft);
        }

        CheckCorrectness();
    }


        private void CheckCorrectness()
{
    // Check if all three correct answers are in their respective slots
    int correctCount = 0;
    for (int i = 0; i < answers.Length; i++)
    {
        float distance = Vector3.Distance(answers[i].transform.localPosition, dropAnswerSlots[i].transform.localPosition);
        if (distance < dropDistances[i])
        {
            correctCount++;
            answerCorrectFlags[i] = true; // Set the answerCorrectFlags flag to true
            MakeAnswerNotDraggable(i); // Disable dragging for this answer
        }
    }

    if (correctCount >= 3) // Assuming you want at least 3 correct answers
    {
        soundControl.gameCompleteSound();
        StartCoroutine(ShowGameCompletionPanel());
    }
    else if (playersLifeValue.lifeLeft <= 0)
    {
        StartCoroutine(ShowGameOverPanelDelayed());
    }

    if (correctCount >= 3) // Assuming you want at least 3 correct answers
{
    soundControl.gameCompleteSound();
    StartCoroutine(ShowGameCompletionPanel());
}
}

    private void MakeAnswerNotDraggable(int answerIndex)
    {
        EventTrigger answerEventTrigger = answers[answerIndex].GetComponent<EventTrigger>();
        answerEventTrigger.enabled = false;
    }

    private IEnumerator ShowGameCompletionPanel()
    {
        // Wait for a delay before showing the game completion panel
        yield return new WaitForSeconds(0.30f); //delay in seconds
        gameCompletePanel.SetActive(true);
        go_backButton.interactable = false;
        go_pauseButton.interactable = false;
        go_retryButton.interactable = false;
        go_instruction.interactable = false;
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
        soundControl.GameOverSound();

        if (playersLifeValue.lifeLeft <= 0)
        {
            // Disable the buttons if the player's life is zero or less
            go_backButton.interactable = false;
            go_pauseButton.interactable = false;
            go_retryButton.interactable = false;
            go_instruction.interactable = false;
        }
    }

    public void loadRandomScenes()
    {
        // Load random scenes for addition game
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
        // Load random scenes for subtraction game
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















