// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;

// public class ControlDragAndDrop : MonoBehaviour
// {
//     public GameObject answer, answer2, answer3; //options
//     Vector2 answerFirstPos, answer2FirstPos, answer3FirstPos; // Position variables for initial positions
//     public GameObject dropAnswerSlot, dropAnswerSlot2, dropAnswerSlot3; // Third slot added
//     public int dropDistance, dropDistance2, dropDistance3; // Drop distances for all options

//     [SerializeField] private GameObject gameCompletePanel;
//     [SerializeField] private ControlSound controlSound;
//     [SerializeField] private PlayerLife playersLife;

//     private bool answer1Correct = false;
//     private bool answer2Correct = false;
//     private bool answer3Correct = false; 
    
//     private EventTrigger answerEventTrigger;

//     void Start()
//     {
//         // Save initial positions
//         answerFirstPos = answer.transform.localPosition;
//         answer2FirstPos = answer2.transform.localPosition;
//         answer3FirstPos = answer3.transform.localPosition;

//         answerEventTrigger = answer.GetComponent<EventTrigger>();


//         playersLife.lifeLeft = 3;
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
//             controlSound.CorrectAnswer();
//             answer1Correct = true; // Set the answer1Correct flag to true
//             MakeAnswerNotDraggable(answerEventTrigger); // Disable dragging for this answer
//         }
//         else
//         {
//             answer.transform.localPosition = answerFirstPos;
//             Debug.Log("Not");
//             controlSound.WrongAnswer();
//             playersLife.lifeLeft--;
//             playersLife.LifeReduce(playersLife.lifeLeft);
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
//              controlSound.CorrectAnswer();
//               answer2Correct = true; // Set the answer1Correct flag to true
//             MakeAnswerNotDraggable(answerEventTrigger); // Disable dragging for this answer
//         }
//         else
//         {
//             answer2.transform.localPosition = answer2FirstPos;
//             Debug.Log("Not");
//             controlSound.WrongAnswer();
//             playersLife.lifeLeft--;
//             playersLife.LifeReduce(playersLife.lifeLeft);
//         }

//         CheckCorrectness();
//     }

//     public void DragAnswer3() // New method for dragging the third option
//     {
//         answer3.transform.position = Input.mousePosition;
//     }

//     public void EndDragAnswer3() // New method for ending drag for the third option
//     {
//         float distance3 = Vector3.Distance(answer3.transform.localPosition, dropAnswerSlot3.transform.localPosition);

//         if (distance3 < dropDistance3)
//         {
//             answer3.transform.localPosition = dropAnswerSlot3.transform.localPosition;
//             Debug.Log("Stick");
//             controlSound.CorrectAnswer();
//         }
//         else
//         {
//             answer3.transform.localPosition = answer3FirstPos;
//             Debug.Log("Not");
//             controlSound.WrongAnswer();

//             playersLife.lifeLeft--;
//             playersLife.LifeReduce(playersLife.lifeLeft);
//         }

//         CheckCorrectness();
//     }

//     private void CheckCorrectness()
//     {
//         // Check if all three answers are in their respective slots
//         bool answer1Correct = Vector3.Distance(answer.transform.localPosition, dropAnswerSlot.transform.localPosition) < dropDistance;
//         bool answer2Correct = Vector3.Distance(answer2.transform.localPosition, dropAnswerSlot2.transform.localPosition) < dropDistance2;
//         bool answer3Correct = Vector3.Distance(answer3.transform.localPosition, dropAnswerSlot3.transform.localPosition) < dropDistance3;


//         if ((answer1Correct && answer2Correct) || (answer1Correct && answer3Correct) || (answer2Correct && answer1Correct)
//         || (answer2Correct && answer3Correct) || (answer3Correct && answer1Correct))
//         {
//           controlSound.gameCompleteSound();
//           StartCoroutine(ShowGameCompletionPanel());
//         }

//     }

//     private void MakeAnswerNotDraggable(EventTrigger eventTrigger)
//     {
//         eventTrigger.enabled = false;
//     }

//     private IEnumerator ShowGameCompletionPanel()
//     {
//         // Wait for a delay before showing the game completion panel
//         yield return new WaitForSeconds(0.30f); // Replace 2.0f with the desired delay in seconds
//         gameCompletePanel.SetActive(true);
//     }
// }
