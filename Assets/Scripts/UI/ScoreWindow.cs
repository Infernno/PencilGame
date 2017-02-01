using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    public Text Label;

    public void Start()
    {
        var time = LocalizationManager.Instance.Get("{TimeLabel}", GameManager.Instance.timer.Minutes,
            GameManager.Instance.timer.Seconds);
        var score = LocalizationManager.Instance.Get("{ScoreLabel}", GameManager.Instance.Score);

        if (Label != null) Label.text = time + "\n\n" + score;
    }
}