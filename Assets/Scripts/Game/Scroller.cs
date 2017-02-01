using System.Collections;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    private const float scrollSpeed = -0.2f;
    private float time;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine("Scroll");

        GameManager.Instance.GameOver += () => { StopCoroutine("Scroll"); };
    }
    
    private IEnumerator Scroll()
    {
        while (true)
        {
            time += 0.01f;

            var x = Mathf.Repeat(time * scrollSpeed, 1);
            var offset = new Vector2(x, 0);

            meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);

            yield return null;
        }
    }
}