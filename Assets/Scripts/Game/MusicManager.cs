using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        GameManager.Instance.GameOver += () =>
        {
            audioSource.Stop();
        };
    }
}