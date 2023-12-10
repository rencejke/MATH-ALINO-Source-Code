using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class G2GameLevelMenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject[] panelGames = new GameObject[8];
    [SerializeField] private GameObject[] games = new GameObject[8];
    [SerializeField] private Button forwardButton, forwardButton2;  
    [SerializeField] private Button backwardButton, backwardButton2, backwardButton3;
    [SerializeField] private ControlSound soundClick;

    private void Start()
    {
       
    }

    public void infoButtonGame(int gameIndex)
    {
        soundClick.SoundClick();
        if (IsValidGameIndex(gameIndex))
        {
            panelGames[gameIndex].SetActive(true);
        }
    }

    public void closeButtonPanel(int gameIndex)
    {
        soundClick.SoundClick();
        if (IsValidGameIndex(gameIndex))
        {
            panelGames[gameIndex].SetActive(false);
        }
    }

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

    public void ActivateGames()
    {
        soundClick.SoundClick();
        forward(true, 3, 4, 5);
        forwardButton2.gameObject.SetActive(true);
        forwardButton.gameObject.SetActive(false);
        backwardButton.gameObject.SetActive(true);
    }

    public void DeactivateGames()
    {
        forward(false, 0, 1, 2);
    }

    public void forward2(bool activate, params int[] gameIndices2)
    {
    
     foreach (int gameIndex in gameIndices2){
        if (IsValidGameIndex2(gameIndex)){
                games[gameIndex].SetActive(activate);                
        }
        }
    }

    private bool IsValidGameIndex2(int gameIndex)
    {
        return gameIndex >= 0 && gameIndex < games.Length;
    }

    public void ActivateGames2()
    {
        soundClick.SoundClick();
        forward2(true, 6, 7);
        forwardButton2.gameObject.SetActive(false);
        backwardButton.gameObject.SetActive(false);
        backwardButton3.gameObject.SetActive(true);

    }

    public void DeactivateGames2()
    {
        forward2(false, 3, 4, 5);
    }


    public void backward1(bool activate, params int[] gameIndices3)
    {
    
     foreach (int gameIndex in gameIndices3){
        if (IsValidGameIndex2(gameIndex)){
                games[gameIndex].SetActive(activate);                
        }
        }
    }

    public void ActivateGames3()
    {
        soundClick.SoundClick();
        backward1(true, 3, 4, 5);
        forwardButton2.gameObject.SetActive(true);
        backwardButton.gameObject.SetActive(true);
        backwardButton3.gameObject.SetActive(false);

    }

    public void DeactivateGames3()
    {
        backward1(false, 6, 7);
    }

    public void backward2(bool activate, params int[] gameIndices4)
    {
    
     foreach (int gameIndex in gameIndices4){
        if (IsValidGameIndex2(gameIndex)){
                games[gameIndex].SetActive(activate);                
        }
        }
    }

    public void ActivateGames4()
    {
        soundClick.SoundClick();
        backward1(true, 0, 1, 2);
        forwardButton.gameObject.SetActive(true);
        forwardButton2.gameObject.SetActive(false);
        backwardButton.gameObject.SetActive(false);
        backwardButton3.gameObject.SetActive(false);

    }

    public void DeactivateGames4()
    {
        backward1(false, 3, 4, 5);
    }


}
