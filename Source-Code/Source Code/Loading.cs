using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
using  UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    float time, second;       

    [SerializeField]public Image fillImage;


    // Start is called before the first frame update
    void Start()
    {
        second = 3;
        Invoke("LoadGame", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 5)
        {
             time += Time.deltaTime;
             fillImage.fillAmount = time / second;
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
