using UnityEngine;

public class CoroutineHandler : MonoBehaviour
{
    private static CoroutineHandler instance;

    public static CoroutineHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CoroutineHandler>();
                if (instance == null)
                {
                    var obj = new GameObject("CoroutineHandler");
                    instance = obj.AddComponent<CoroutineHandler>();
                }
            }
            return instance;
        }
    }
}
