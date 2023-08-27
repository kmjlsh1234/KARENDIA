using UnityEngine;

public abstract class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if(instance==null)
                {
                    Debug.LogError("Singleton instance not Found");
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else if (instance != this)
        {
            Debug.LogError("Duplicate singleton instance found! : " + gameObject.name);
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
