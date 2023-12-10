using UnityEngine;
using TMPro;

public class UpdateScoreInOtherGamePanel : MonoBehaviour
{
   
    public TextMeshProUGUI scoreChallengeText;

    // Define an UpdateScore method to update the score text
    public void UpdateScore(int newScore)
    {
        scoreChallengeText.text = newScore.ToString();
    }
}
