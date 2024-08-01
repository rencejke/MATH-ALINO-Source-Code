using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerateQuestion : MonoBehaviour
{
    public int typeQuestion;

    public TextMeshProUGUI textQuestion;
    public int rightAnswer;

    public GameObject[] answers;
    public int[] answerValue;

    // Start is called before the first frame update
    void Start()
    {
        answerValue = new int[answers.Length]; //create an array value according to the number of answers
        Question();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Question()
    {
        switch (typeQuestion)
        {
            case 0://addition
            int a = Random.Range(1, 99);
            int b = Random.Range(1, 99);
            // int c = Random.Range(0, 99);

            textQuestion.text = a + " + " + b; //a + b
            rightAnswer = a + b;
            Debug.Log("Answer Key: " + rightAnswer);
            break; 

            case 1://subtract
            int a1 = Random.Range(0, 99);
            int b1 = Random.Range(0, a1);
            // int c1 = Random.Range(0, 99);

            textQuestion.text = a1 + " - " + b1 + " = "; //a1 - b1
            rightAnswer = a1 - b1;
            Debug.Log("Answer Key: " + rightAnswer);
            break;

            case 2://multiplication
            int a2 = Random.Range(1, 99);
            int b2 = Random.Range(1, 99);
            // int c2 = Random.Range(0, 99);

            textQuestion.text = a2 + " x " + b2 + " = "; //a2 * b2
            rightAnswer = a2 * b2;
            Debug.Log("Answer Key: " + rightAnswer);
            break;

            case 3://division
            int a3 = Random.Range(1, 99);
            int b3 = Random.Range(1, 99);
            // int c3 = Random.Range(0, 99);

            textQuestion.text = (a3 * b3) + " / " + b3 + " = "; //a3 / b3
            rightAnswer = (a3 * b3) / b3;
             Debug.Log("Answer Key: " + rightAnswer);
            break;


            //GRADE 2

            case 4://addition-GRADE2
            int c = Random.Range(1, 500);
            int d = Random.Range(1, 500);
            

            textQuestion.text = c + " + " + d; //c + d
            rightAnswer = c + d;
            Debug.Log("Answer Key: " + rightAnswer);
            break; 

            case 5://subtract-GRADE2
            int c1 = Random.Range(1, 1000);
            int d1 = Random.Range(1, c1);
        

            textQuestion.text = c1 + " - " + d1; //c1 - d1
            rightAnswer = c1 - d1;
            Debug.Log("Answer Key: " + rightAnswer);
            break;

            case 6://multiplication-GRADE2
            int c2 = Random.Range(1, 10);
            int d2 = Random.Range(1, 10);
         

            textQuestion.text = c2 + " x " + d2; //c2 * d2
            rightAnswer = c2 * d2;
            Debug.Log("Answer Key: " + rightAnswer);
            break;

            case 7://division-GRADE2
            int c3 = Random.Range(1, 50);
            int d3 = Random.Range(1, 25);
            
            textQuestion.text = (c3 * d3) + " / " + d3; //c3 / d3
            rightAnswer = (c3 * d3) / d3;
             Debug.Log("Answer Key: " + rightAnswer);
            break;

            //GRADE 3

            case 8://addition-GRADE3
            int e = Random.Range(1, 5000);
            int f = Random.Range(1, 5000);
            // int g = Random.Range(0, 99);

            textQuestion.text = e + " + " + f; //e + f
            rightAnswer = e + f;
            Debug.Log("Answer Key: " + rightAnswer);
            break; 

            case 9://subtract-GRADE3
            int e1 = Random.Range(1, 10000);
            int f1 = Random.Range(1, e1);
           
            textQuestion.text = e1 + " - " + f1; //e1 - f1
            rightAnswer = e1 - f1;
            Debug.Log("Answer Key: " + rightAnswer);
            break;

            case 10://multiplication-GRADE3
            int e2 = Random.Range(1, 100);
            int f2 = Random.Range(1, 100);

            textQuestion.text = e2 + " x " + f2; //e2 * f2
            rightAnswer = e2 * f2;
            Debug.Log("Answer Key: " + rightAnswer);
            break;

            case 11://division-GRADE3
            int e3 = Random.Range(1, 100);
            int f3 = Random.Range(1, 50);

            textQuestion.text = (e3 * f3) + " / " + f3; 
            rightAnswer = (e3 * f3) / f3;
             Debug.Log("Answer Key: " + rightAnswer);
            break;

            default:
            break;
        }

        for (int i = 0; i < answers.Length; i++)
        {
            if (i == 0)
            {
                answerValue[i] = rightAnswer;
            }
            else
            {
                answerValue[i] = answerValue[i - 1] + Random.Range(1, 5); // 1 2 3 4
            }
        }
        RandomKeyAnswers();

        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].transform.GetChild(0).GetComponent<TMP_Text>().text = answerValue[i].ToString(); 
        }
    }

    void RandomKeyAnswers()
    {
        for (int i = 0; i < answers.Length; i++)
        {
            int a = answerValue[i];
            int b = Random.Range(0, answerValue.Length);
            answerValue[i] = answerValue[b];
            answerValue[b] = a;
        }
    }
}
