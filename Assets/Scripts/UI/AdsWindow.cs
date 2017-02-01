using UnityEngine;

public class AdsWindow : MonoBehaviour
{
    private void Start()
    {
        if (!AdsManager.AdsWindowWasShown)
            AdsManager.AdsWindowWasShown = true;
    }

    public void ShowAdWindow()
    {
        if (!AdsManager.AdsWindowWasShown)
            gameObject.SetActive(true);
    }
}