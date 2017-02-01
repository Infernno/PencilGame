using Newtonsoft.Json;
using UnityEngine;

public static class Utils
{
    private static int previousColor = -1;

    public static int RandomNumber(int min, int max, int except)
    {
        int output = Random.Range(min, max);

        while (output == except) { output = Random.Range(min, max); }

        return output;
    }

    public static Color GetColor()
    {
        int currentColor = RandomNumber(0, 4, previousColor);

        previousColor = currentColor;

        switch (currentColor)
        {
            case 0:
                return Color.red;
            case 1:
                return Color.green;
            case 2:
                return Color.blue;
            case 3:
                return Color.yellow;
            default:
                return Color.grey;
        }
    }

    public static T LoadJSON<T>(string path)
    {
        var content = Resources.Load<TextAsset>(path).text;
        return JsonConvert.DeserializeObject<T>(content);
    }

    public static bool Parse(this int i)
    {
        return i == 1;
    }

    public static int Parse(this bool boolean)
    {
        return boolean ? 1 : 0;
    }
}