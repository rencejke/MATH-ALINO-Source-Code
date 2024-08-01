using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionHandler : MonoBehaviour
{

    [SerializeField] RectTransform fader;

    private void Start()
    {
        fader.gameObject.SetActive(true);

        //ALPHA
        LeanTween.alpha (fader, 1, 0);
        LeanTween.alpha (fader, 0, 0.5f).setOnComplete(() => {
            fader.gameObject.SetActive(false);
        });

        //SCALE
        // LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        // LeanTween.scale(fader, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() => {
        //     fader.gameObject.SetActive(false);
        // });
    }
   
    public void OpenStartScene()
    {
       fader.gameObject.SetActive(true);
       
       //ALPHA
        LeanTween.alpha (fader, 0, 0);
        LeanTween.alpha (fader, 1, 0.5f).setOnComplete(() => {
            fader.gameObject.SetActive(false);
        });

       
        //SCALE
        // LeanTween.scale(fader, Vector3.zero, 0f);
        // LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() => {
        //      SceneManager.LoadScene(0);
        // });
    }

    public void OpenGameScene() 
    {
        fader.gameObject.SetActive(true);
        //ALPHA
        LeanTween.alpha (fader, 0, 0);
        LeanTween.alpha (fader, 1, 0.5f).setOnComplete(() => {
            fader.gameObject.SetActive(false);
        });

        //SCALE
        // LeanTween.scale(fader, Vector3.zero, 0f);
        // LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() => {
        //      SceneManager.LoadScene(1);
        // });
    }
}
