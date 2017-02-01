using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public bool TestMode;

    private static int counterForAds = 2;
    private const int counterReset = 3;

    private static bool showAds = true;

    public static bool ShowAds
    {
        get
        {
            Check();
            return showAds;
        }
        set
        {
            PlayerPrefs.SetInt(R.PlayerPrefsTags.ADS, value.Parse());
            showAds = value;
        }
    }

    public static bool AdsWindowWasShown
    {
        get
        {
            return PlayerPrefs.HasKey(R.PlayerPrefsTags.ADS_WINDOW) && PlayerPrefs.GetInt(R.PlayerPrefsTags.ADS_WINDOW).Parse();
        }
        set
        {
            PlayerPrefs.SetInt(R.PlayerPrefsTags.ADS_WINDOW, value.Parse());
        }
    }

    private void Awake()
    {
        Check();

        if (Advertisement.isSupported)  
            Advertisement.Initialize(R.Constants.UNITY_ADS_GAMEID, TestMode);
        else
            Debug.Log("[Unity Ads]: Platform not supported"); 
    }

    private void Start()
    {
        GameManager.Instance.GameOver += () =>
        {
            if (showAds)
            {
                counterForAds --;

                if (counterForAds <= 0)
                {
                    counterForAds = counterReset;

                    if (Advertisement.IsReady("rewardedVideoZone")) { Advertisement.Show("rewardedVideoZone"); }
                }
            }
        };
    }

    private static void Check()
    {
        if (PlayerPrefs.HasKey(R.PlayerPrefsTags.ADS))
            showAds = PlayerPrefs.GetInt(R.PlayerPrefsTags.ADS).Parse();
    }
}