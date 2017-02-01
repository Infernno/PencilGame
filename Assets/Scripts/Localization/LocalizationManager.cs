using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : Singleton<LocalizationManager>
{
    private readonly Dictionary<string, string> translation = new Dictionary<string, string>();

    public string Get(string key)
    {
        return translation[key];
    }

    public string Get(string key, params object[] args)
    {
        return string.Format(Get(key), args);
    }

    private void Awake()
    {
        var data = Utils.LoadJSON<Dictionary<SystemLanguage, Dictionary<string, string>>>(R.Constants.LOCALIZATION_FILE);

        var lang = data.ContainsKey(Application.systemLanguage) ? Application.systemLanguage : SystemLanguage.English;

        foreach (var pair in data[lang])
            translation.Add(pair.Key, pair.Value);
    }
}