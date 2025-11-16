using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : Component
{
    private static T inst;

    public static T Instance
    {
        get
        {
            if (inst == null)
            {
                inst = (T)FindFirstObjectByType(typeof(T));

                if (inst == null)
                {
                    GameObject gameObject = new GameObject();
                    inst = gameObject.AddComponent<T>();

                    gameObject.name = typeof(T).Name;

                    DontDestroyOnLoad(gameObject);
                }
            }
            return inst;
        }
    }
    public virtual void Awake()
    {
        if (inst == null)
        {
            inst = this as T;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
