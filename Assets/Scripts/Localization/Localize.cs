using UnityEngine;
using UnityEngine.UI;

public class Localize : MonoBehaviour
{
    private void Start()
    {
        var label = GetComponent<Text>();

        if (label != null) { label.text = LocalizationManager.Instance.Get(label.text); }
    }
}
