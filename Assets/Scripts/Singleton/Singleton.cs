using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var gameObj = new GameObject(typeof(T).ToString());
                instance = gameObj.AddComponent<T>();

            //    DontDestroyOnLoad(gameObj);

                Debug.LogFormat("[Singleton]: An instance of {0} is created in the scene", gameObj.name);
            }

            return instance;
        }
    }
}