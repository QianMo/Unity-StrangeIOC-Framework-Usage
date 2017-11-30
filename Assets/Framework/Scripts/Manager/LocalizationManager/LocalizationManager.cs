//-------------------------------------------------------------------------------------
//	LocalizationManager.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager
{
    private static LocalizationManager _instance;
    public static LocalizationManager Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = new LocalizationManager();
            }
            return _instance;
        }
    }

    public void Init()
    {

    }

    private const string Chinese = "Localization/Chinese";
    private const string English = "Localization/English";

    public const string Language = English;

    private Dictionary<string, string> dict = new Dictionary<string, string>();



    public LocalizationManager()
    {
        dict = new Dictionary<string, string>();

        TextAsset ta= Resources.Load<TextAsset>(Language);
        if (ta==null)
        {
            Debug.Log("[LocalizationManager]TextAsset Load fail! TextAsset==null");
            return;
        }
        string[] lines = ta.text.Split('\n');
        foreach ( string line in  lines)
        {
            if (string.IsNullOrEmpty(line) == false)
            {
                string[] keyvalues = line.Split('=');
                dict.Add(keyvalues[0], keyvalues[1]);
            }
        }
    }

    public string GetValue(string key)
    {
        string value;
        dict.TryGetValue(key, out value);
        return value;
    }


}
