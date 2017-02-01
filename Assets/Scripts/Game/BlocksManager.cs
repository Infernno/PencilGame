using System.Collections;
using UnityEngine;

public class BlocksManager : MonoBehaviour
{
    public static float Speed { get; private set; }
    private const float MaxSpeed = 4f;

    private void Start()
    {
        Speed = 0.8f;

        GameManager.Instance.GameStart += () => { StartCoroutine("IncreaseSpeed"); };
        GameManager.Instance.GameOver += () => { StopCoroutine("IncreaseSpeed"); };
        GameManager.Instance.GameReloading += () => { Speed = 0.8f; };
    }

    private IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            if (Speed >= MaxSpeed) yield break;
            yield return  new WaitForSeconds(4f);

            Speed += 0.1f;

            #if UNITY_EDITOR
            Debug.Log("Speed increased to " + Speed);
            #endif
        }
    }
}