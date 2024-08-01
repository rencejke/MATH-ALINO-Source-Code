using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ControlDragAndDropForFour: MonoBehaviour
{
    [Header("Options")]
    public GameObject[] answers; // Options
    private Vector2[] answerFirstPositions; // Position variables for initial positions

    [Header("Drop Slots")]
    public GameObject[] dropAnswerSlots; // Drop slots for options
    public int[] dropDistances; // Drop distances for all options

    [Header("UI Panels and Buttons")]
    [SerializeField] private GameObject gameCompletePanel, gameOverPanel;
    [SerializeField] private Button go_pauseButton, go_backButton, go_retryButton, go_instructionsButton;

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

    if (correctCount >= 4) // Assuming you want at least 7 correct answers
    {
        soundControl.gameCompleteSound();
        StartCoroutine(ShowGameCompletionPanel());
    }
    else if (playersLifeValue.lifeLeft <= 0)
    {
        StartCoroutine(ShowGameOverPanelDelayed());
    }

    if (correctCount >= 4) // Assuming you want at least 2 correct answers
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

        go_pauseButton.interactable = false;
        go_backButton.interactable = false;
        go_retryButton.interactable = false;
        go_instructionsButton.interactable = false;
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
            go_instructionsButton.interactable = false;
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
