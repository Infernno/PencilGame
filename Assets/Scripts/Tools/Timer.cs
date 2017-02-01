using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float Minutes { get; private set; }
    public float Seconds { get; private set; }

    private float startTime;
    private float deltaTime;

    public void Begin()
    {
        startTime = Time.time;
        StartCoroutine("Count");
    }

    public void Stop()
    {
        StopCoroutine("Count");
    }

    public void Reset()
    {
        startTime = 0f;
        deltaTime = 0f;

        Minutes = 0f;
        Seconds = 0f;
    }

    private IEnumerator Count()
    {
        while (true)
        {
            deltaTime = Time.time - startTime;

            Minutes = Mathf.Floor(deltaTime / 60f);
            Seconds = deltaTime % 60f;

            yield return null;
        }
    }
}