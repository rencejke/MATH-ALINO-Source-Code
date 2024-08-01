using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioCorrect, audioWrong, audioGameComplete, audioGameOver, ButtonClickSound;

     private bool muted = false;

    

    public void SoundClick()
    {
        audioSource.PlayOneShot(ButtonClickSound);
    }

    public void CorrectAnswer()
    {
        audioSource.PlayOneShot(audioCorrect);
    }

     public void WrongAnswer()
    {
        audioSource.PlayOneShot(audioWrong);
    }

     public void gameCompleteSound()
    {
        audioSource.PlayOneShot(audioGameComplete);
    }

     public void GameOverSound()
    {
        audioSource.PlayOneShot(audioGameOver);
    }

}

