using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu( fileName = "SceneManager")]
public class SceneLoader : ScriptableObject
{
    private Stack<int> loadedLevels;

    [System.NonSerialized]
    private bool initialized;

    private void Init()
    {
        loadedLevels = new Stack<int>();
        initialized = true;
    }
 
    public UnityEngine.SceneManagement.Scene GetActiveScene()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }
    
    public void LoadScene( int buildIndex )
    {
        if ( !initialized ) Init();
        loadedLevels.Push( GetActiveScene().buildIndex );
        UnityEngine.SceneManagement.SceneManager.LoadScene( buildIndex );
        Time.timeScale = 1.0f;
    }

    public void LoadScene( string sceneName )
    {
        if ( !initialized ) Init();
        loadedLevels.Push( GetActiveScene().buildIndex );
        UnityEngine.SceneManagement.SceneManager.LoadScene( sceneName );
        Time.timeScale = 1.0f;
    }

    public void LoadPreviousScene()
    {
        if ( !initialized )
        {
            Debug.LogError( "You haven't used the LoadScene functions of the scriptable object. Use them instead of the LoadScene functions of Unity's SceneManager." );
        }
        if ( loadedLevels.Count > 0 )
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene( loadedLevels.Pop() );
            Time.timeScale = 1.0f;
            scoreChallengeManager.score = 0;
        }
        else
        {
            Debug.LogError( "No previous scene loaded" );
            // If you want, you can call `Application.Quit()` instead
        }
    }

    public void RetryButton2()
    {
        // Load the current scene to restart the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}