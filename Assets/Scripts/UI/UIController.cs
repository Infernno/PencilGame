using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text ScoreLabel;

    public GameObject[] EnableOnStart;
    public GameObject[] HideOnStart;
    public GameObject[] HideOnGameOver;

    public GameObject ScoreWindow;

    private void Start()
    {
        GameManager.Instance.GameStart += () =>
        {
            for(int i = 0; i < EnableOnStart.Length; i++) EnableOnStart[i].SetActive(true);
            for(int i = 0; i < HideOnStart.Length; i++) HideOnStart[i].SetActive(false);
        };

        GameManager.Instance.BlockDestroyed += () => { ScoreLabel.text = GameManager.Instance.Score.ToString(); };

        GameManager.Instance.GameOver += () =>
        {
            for (int i = 0; i < HideOnGameOver.Length; i++) HideOnGameOver[i].SetActive(false);
            ScoreWindow.SetActive(true);
        };
    }

    public void ControlTime()
    {
        Time.timeScale = Mathf.Abs(Time.timeScale) > 0f ? 0f : 1f;
    }

    public void ControlAudio()
    {
        AudioListener.volume = Mathf.Abs(AudioListener.volume) > 0f ? 0f : 1f;
    }

    public void ControlAds()
    {
        AdsManager.ShowAds = !AdsManager.ShowAds;
    }

    public void Restart()
    {
        GameManager.Instance.OnGameReloading();

        Time.timeScale = 1f;
        Application.LoadLevel(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void HandlePanel(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }
}