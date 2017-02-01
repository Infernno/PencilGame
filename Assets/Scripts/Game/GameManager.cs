using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static bool isReloaded;

    public event Method GameStart;
    public event Method BlockDestroyed;
    public event Method GameOver;
    public event Method GameReloading;

    public void OnGameStart() { if (GameStart != null) GameStart(); }
    public void OnBlockDestroyed() { if (BlockDestroyed != null) BlockDestroyed(); }
    public void OnGameOver() { if (GameOver != null) GameOver(); }
    public void OnGameReloading() { if (GameReloading != null) GameReloading(); }

    public int Score { get; private set; }
    public Timer timer { get; private set; }

    private bool isLaunched;

    private void Awake()
    {
        timer = gameObject.AddComponent<Timer>();

        GameStart += timer.Begin;
        GameOver += timer.Stop;

        GameReloading += timer.Stop;
        GameReloading += timer.Reset;

        BlockDestroyed += () => { Score += 1; };

        if (!isReloaded) GameReloading += () => { isReloaded = true; };
    }

    private void Start()
    {
        if (isReloaded)
        {
            OnGameStart();
        }
    }

#if !UNITY_EDITOR
    private void Update()
    {
        if (!isLaunched && !isReloaded)
        {
            if (Input.touchCount > 0)
            {
                OnGameStart();
                isLaunched = true;
            }
        } 
    }
#else
    private void Update()
    {
        if (!isLaunched && !isReloaded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnGameStart();
                isLaunched = true;
            }
        }
    }
#endif
}
