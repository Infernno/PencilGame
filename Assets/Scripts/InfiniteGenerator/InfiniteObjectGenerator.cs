using System.Collections;
using UnityEngine;

public class InfiniteObjectGenerator : MonoBehaviour
{
    public Transform Block;

    private readonly Vector3 SpawnPoint = new Vector3(6f, 0f);
    private Transform lastItem;

    private const float Threshold = 4f;

    private void Start()
    {
        GameManager.Instance.GameStart += () => { StartCoroutine("Spawn"); };
        GameManager.Instance.GameReloading += Stop;
        GameManager.Instance.GameOver += Stop;
    }

    private IEnumerator Spawn()
    {
        CreateBlock();

        while (true)
        {
            if ((lastItem.position - SpawnPoint).sqrMagnitude >= Threshold)
                CreateBlock();

            yield return null;
        }
    }

    private void CreateBlock()
    {
        lastItem = (Transform) Instantiate(Block, SpawnPoint, Quaternion.identity);
    }

    private void Stop()
    {
        StopCoroutine("Spawn"); lastItem = null;
    }
}