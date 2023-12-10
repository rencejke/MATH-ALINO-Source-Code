using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChallengeGameMenuManager : MonoBehaviour
{
   [Header("UI Panels")]
    [SerializeField] private GameObject[] games = new GameObject[3];
    [SerializeField] private Button forwardButton;
    [SerializeField] private Button backwardButton;
    [SerializeField] private ControlSound soundClick;

   


   public void forward(bool activate, params int[] gameIndices)
    {
        foreach (int gameIndex in gameIndices)
        {
            if (IsValidGameIndex(gameIndex))
            {
                games[gameIndex].SetActive(activate);
            }
        }
    }

    private bool IsValidGameIndex(int gameIndex)
    {
        return gameIndex >= 0 && gameIndex < games.Length;
    }

    public void G2ActivateDivisionMult()
    {
        soundClick.SoundClick();
        forward(true, 2, 3);
        forwardButton.gameObject.SetActive(false);
        backwardButton.gameObject.SetActive(true);
    }

    public void DeactivateGames()
    {
        forward(false, 0, 1);
    }

     private bool IsValidGameIndex2(int gameIndex)
    {
        return gameIndex >= 0 && gameIndex < games.Length;
    }

    public void backward(bool activate, params int[] gameIndices3)
    {
    
     foreach (int gameIndex in gameIndices3)
     {
        if (IsValidGameIndex2(gameIndex)){
                games[gameIndex].SetActive(activate);                
        }
        }
    }

    public void G2ActivateDivisionMult2()
    {
        soundClick.SoundClick();
        backward(true, 0, 1);
        forwardButton.gameObject.SetActive(true);
        backwardButton.gameObject.SetActive(false);
    }

    public void DeactivateGames2()
    {
        backward(false, 2, 3);
    }
}
