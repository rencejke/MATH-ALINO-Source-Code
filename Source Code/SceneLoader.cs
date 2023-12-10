// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class SceneLoader : MonoBehaviour
// {
//     [SerializeField] private ControlSound controlClick;

//     public void LoadMainMenuScene()
//     {
//         controlClick.SoundClick();
//         StartCoroutine(SceneMaanager.LoadSceneWithDelay("Grade1GameSelectionMenu", 0.5F));
//     }

//     public void LoadGradeSelectionScene()
//     {
//         controlClick.SoundClick();
//         Time.timeScale = 1;
//         StartCoroutine(SceneMaanager.LoadSceneWithDelay("GradeLevelMenu", 0.5F));
//     }

//       public void LoadAdditonGameGrade1()
//     {
//         controlClick.SoundClick();
//         Time.timeScale = 1;
//         StartCoroutine(SceneMaanager.LoadSceneWithDelay("AdditionGame", 0.5F));
//     }

//      public void LoadOptionScene()
//     {
//         controlClick.SoundClick();
//         Time.timeScale = 1;
//         StartCoroutine(SceneMaanager.LoadSceneWithDelay("Options", 0.5F));
//     }

//      public void LoadOptionAddGameScene()
//     {
//         controlClick.SoundClick();
//         Time.timeScale = 1;
//         StartCoroutine(SceneMaanager.LoadSceneWithDelay("OptionsAddGame", 0.5F));
//     }
    

//     public void RetryButton2()
//     {
//     // Load the current scene to restart the game
//     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//     Time.timeScale = 1;
//     }


   //  public void Home()
   //  {   
   //      Time.timeScale = 1f;      
   //      controlClick.SoundClick();
   //      StartCoroutine(SceneMaanager.LoadSceneWithDelay("Start", 0.5F));
   //  }
// }

// //////////////////////////////////

// // using UnityEngine;
// // using System.Collections.Generic;
// // using UnityEngine.SceneManagement;

// // [CreateAssetMenu( fileName = "SceneManager")]
// // public class SceneLoader : ScriptableObject
// // {
// //     private Stack<int> loadedLevels;


// //     [System.NonSerialized]
// //     private bool initialized;

// //     private void Init()
// //     {
// //         loadedLevels = new Stack<int>();
// //         initialized = true;
// //     }
 
// //     public UnityEngine.SceneManagement.Scene GetActiveScene()
// //     {
// //         return UnityEngine.SceneManagement.SceneManager.GetActiveScene();
// //     }
    
// //     public void LoadScene( int buildIndex )
// //     {
// //         if ( !initialized ) Init();
// //         loadedLevels.Push( GetActiveScene().buildIndex );
// //         UnityEngine.SceneManagement.SceneManager.LoadScene( buildIndex );
// //     }

// //     public void LoadScene( string sceneName )
// //     {
// //         if ( !initialized ) Init();
// //         loadedLevels.Push( GetActiveScene().buildIndex );
// //         UnityEngine.SceneManagement.SceneManager.LoadScene( sceneName );
// //     }

// //     public void LoadPreviousScene()
// //     {
// //         if ( !initialized )
// //         {
// //             Debug.LogError( "You haven't used the LoadScene functions of the scriptable object. Use them instead of the LoadScene functions of Unity's SceneManager." );
// //         }
// //         if ( loadedLevels.Count > 0 )
// //         {   
// //             UnityEngine.SceneManagement.SceneManager.LoadScene( loadedLevels.Pop() );
// //         }
// //         else
// //         {
// //             Debug.LogError( "No previous scene loaded" );
// //             // If you want, you can call `Application.Quit()` instead
// //         }
// //     }

// //      public void RetryButton2()
// //     {
// //     // Load the current scene to restart the game
// //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
// //     Time.timeScale = 1;
// //     }
// // }


// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.SceneManagement;

// [CreateAssetMenu(fileName = "SceneManager")]
// public class SceneLoader : ScriptableObject
// {
//     private Stack<int> loadedLevels;
//     private bool initialized;

//     private void Init()
//     {
//         if (loadedLevels == null)
//             loadedLevels = new Stack<int>();

//         initialized = true;
//     }

//     public UnityEngine.SceneManagement.Scene GetActiveScene()
//     {
//         return UnityEngine.SceneManagement.SceneManager.GetActiveScene();
//     }

//     public void LoadScene(int buildIndex)
//     {
//         if (!initialized)
//             Init();

//         if (loadedLevels != null)
//         {
//             // Store the current scene's build index as the previous scene
//             int previousBuildIndex = GetActiveScene().buildIndex;
//             loadedLevels.Push(previousBuildIndex);
//         }

//         if (CoroutineHandler.Instance != null)
//             CoroutineHandler.Instance.StartCoroutine(DelayedLoadScene(buildIndex));

//         Time.timeScale = 1; // Resume the game by setting Time.timeScale to 1
//     }

//     public void LoadScene(string sceneName)
//     {
//         if (!initialized)
//             Init();

//         if (loadedLevels != null)
//         {
//             // Store the current scene's build index as the previous scene
//             int previousBuildIndex = GetActiveScene().buildIndex;
//             loadedLevels.Push(previousBuildIndex);
//         }

//         if (CoroutineHandler.Instance != null)
//             CoroutineHandler.Instance.StartCoroutine(DelayedLoadScene(sceneName));

//         Time.timeScale = 1; // Resume the game by setting Time.timeScale to 1
//     }

//     public void LoadPreviousScene()
//     {
//         if (!initialized)
//         {
//             Debug.LogError("You haven't used the LoadScene functions of the scriptable object. Use them instead of the LoadScene functions of Unity's SceneManager.");
//             return;
//         }

//         if (loadedLevels != null && loadedLevels.Count > 0)
//         {
//             int previousBuildIndex = loadedLevels.Pop();
//             Debug.Log("Loading previous scene with build index: " + previousBuildIndex);
//             UnityEngine.SceneManagement.SceneManager.LoadScene(previousBuildIndex);
//         }
//         else
//         {
//             Debug.LogError("No previous scene loaded");
//             // If you want, you can call `Application.Quit()` instead
//         }
//     }

//     private IEnumerator DelayedLoadScene(int buildIndex)
//     {
//         yield return new WaitForSeconds(1f); // Delay of 1 second (change as needed)
//         Debug.Log("Loading scene with build index: " + buildIndex);
//         UnityEngine.SceneManagement.SceneManager.LoadScene(buildIndex);
//         Time.timeScale = 1; // Resume the game by setting Time.timeScale to 1
//     }

//     private IEnumerator DelayedLoadScene(string sceneName)
//     {
//         yield return new WaitForSeconds(0.50f); //Delay of 0.5 seconds (change as needed)
//         Debug.Log("Loading scene with name: " + sceneName);
//         UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
//         Time.timeScale = 1;
//     }

//     public void RetryButton2()
//     {
//         // Load the current scene to restart the game
//         LoadScene(GetActiveScene().buildIndex);
//     }
// }




// using UnityEngine;
// using System.Collections.Generic;

// [CreateAssetMenu( fileName = "SceneManager")]
// public class SceneLoader : ScriptableObject
// {
//     private Stack<int> loadedLevels;

//     [System.NonSerialized]
//     private bool initialized;

//     private void Init()
//     {
//         loadedLevels = new Stack<int>();
//         initialized = true;
//     }
 
//     public UnityEngine.SceneManagement.Scene GetActiveScene()
//     {
//         return UnityEngine.SceneManagement.SceneManager.GetActiveScene();
//     }
    
//     public void LoadScene( int buildIndex )
//     {
//         if ( !initialized ) Init();
//         loadedLevels.Push( GetActiveScene().buildIndex );
//         UnityEngine.SceneManagement.SceneManager.LoadScene( buildIndex );
//     }

//     public void LoadScene( string sceneName )
//     {
//         if ( !initialized ) Init();
//         loadedLevels.Push( GetActiveScene().buildIndex );
//         UnityEngine.SceneManagement.SceneManager.LoadScene( sceneName );
//     }

//     public void LoadPreviousScene()
//     {
//         if ( !initialized )
//         {
//             Debug.LogError( "You haven't used the LoadScene functions of the scriptable object. Use them instead of the LoadScene functions of Unity's SceneManager." );
//         }
//         if ( loadedLevels.Count > 0 )
//         {
//             UnityEngine.SceneManagement.SceneManager.LoadScene( loadedLevels.Pop() );
//         }
//         else
//         {
//             Debug.LogError( "No previous scene loaded" );
//             // If you want, you can call `Application.Quit()` instead
//         }
//     }
// }