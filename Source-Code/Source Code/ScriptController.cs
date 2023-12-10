using UnityEngine;

public class ScriptController : MonoBehaviour
{
    // Static reference to the instance of this class
    private static ScriptController instance;

    // This will be executed when the object wakes up
    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this instance
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Otherwise, set this instance as the main instance and don't destroy it on scene changes
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
