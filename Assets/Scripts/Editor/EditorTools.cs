using UnityEngine;
using UnityEditor;

public class EditorTools : Editor
{
    [MenuItem("Tools/Clear PlayerPrefs")]
    public static void Clear()
    {
        PlayerPrefs.DeleteAll();
    }
}