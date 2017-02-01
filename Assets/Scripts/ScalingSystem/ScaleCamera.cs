using UnityEngine;

[ExecuteInEditMode]
public class ScaleCamera : MonoBehaviour
{
    public int targetWidth = 640;
    public float pixelsToUnits = 100;

#if UNITY_EDITOR
    private void Update()
#else
        private void Start()
#endif
    {
        var height = Mathf.RoundToInt(targetWidth / (float) Screen.width * Screen.height);

        GetComponent<Camera>().orthographicSize = height / pixelsToUnits / 2f;
    }
}